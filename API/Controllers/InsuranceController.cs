using Application.VSContractInsurancePolicy;
using Application.VSInsurancePolicy;
using Application.Wrappers;
using Domain.ContractInsurancePolicyEntity;
using Microsoft.AspNetCore.Mvc;
using sureApp.Application.VSCustomer;
using sureApp.domain.CustomerEntity;
using sureApp.domain.ValueObjects;

namespace API.Controllers
{
    /// <summary>
    /// No es ideal que un endpoint controller tenga tanto codigo pero me estoy viendo cogido de tiempo y el codigo escalable es mejorable
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsurancePolicyService _ownService;
        private readonly ICustomerService _customerService;
        private readonly IContractInsurancePolicyService _contractService;
        public InsuranceController(IInsurancePolicyService services, ICustomerService customer,IContractInsurancePolicyService contract) {
            _ownService = services;
            _customerService = customer;
            _contractService = contract;
        }

        [HttpGet("plate/{plate}")] public async Task<IActionResult> Get(string plate)
        {
            
            var customers = await _customerService.GetAllAsync();
            var insurances = await _ownService.GetAllAsync();
            var result = await _contractService.GetAllAsync();
            //if(customers is null && insurances != null)
            //{

            //}


            var request = result
                .Where(contract => contract.Vehicle.Plate == plate)
                .Join(insurances,
                contract => contract.InsurancePolicyIdentifier,
                insurance => insurance.Identifier,
                (contract, insurance) => new { Contract = contract, Insurance = insurance })
                .Join(customers,
                joineds => joineds.Contract.CustomerUuid,
                customer => customer.Id,
                (joined, customer) => new 
                {
                    PolicyNumberId = joined.Contract.PolicyContractNumber,
                    CustomerName = customer.Name,
                    CustomerIdentification = customer.IdentificationNumber,
                    CustomerBirthDate = customer.BirthDate,
                    createAt = joined.Contract.CreateAt,
                    CoverageValues = string.Join("," ,joined.Insurance.FeaturesId),
                    MaxCoverageMoney = joined.Insurance.MaximunCoverageValue,
                    PolicyName = joined.Insurance.Name,
                    ClientCity = customer.HomeTown,
                    ClientAddress = customer.Address,
                    VehiclePlate = joined.Contract.Vehicle.Plate,
                    VehicleModel = joined.Contract.Vehicle.Model,
                    IsInspectedTheVehicle = joined.Contract.Vehicle.IsItInspected
                }).FirstOrDefault();
            if (request is null)
            {
                return BadRequest(new ResponseResult<string>(false, "Not found", null, null));
            }
            return Ok(request);

        }
        [HttpGet("policy/{number}")]
        public async Task<IActionResult> Get(long number)
        {

            var customers = await _customerService.GetAllAsync();
            var insurances = await _ownService.GetAllAsync();
            var result = await _contractService.GetAllAsync();
            var request = result
                .Where(contract => contract.PolicyContractNumber == number)
                .Join(insurances,
                contract => contract.InsurancePolicyIdentifier,
                insurance => insurance.Identifier,
                (contract, insurance) => new { Contract = contract, Insurance = insurance })
                .Join(customers,
                joineds => joineds.Contract.CustomerUuid,
                customer => customer.Id,
                (joined, customer) => new
                {
                    PolicyNumberId = joined.Contract.PolicyContractNumber,
                    CustomerName = customer.Name,
                    CustomerIdentification = customer.IdentificationNumber,
                    CustomerBirthDate = customer.BirthDate,
                    createAt = joined.Contract.CreateAt,
                    CoverageValues = string.Join(",", joined.Insurance.FeaturesId),
                    MaxCoverageMoney = joined.Insurance.MaximunCoverageValue,
                    PolicyName = joined.Insurance.Name,
                    ClientCity = customer.HomeTown,
                    ClientAddress = customer.Address,
                    VehiclePlate = joined.Contract.Vehicle.Plate,
                    VehicleModel = joined.Contract.Vehicle.Model,
                    IsInspectedTheVehicle = joined.Contract.Vehicle.IsItInspected
                }).FirstOrDefault();
            if (request is null)
            {
                return BadRequest(new ResponseResult<string>(false, "Not found", null, null));
            }
            return Ok(request);

        }

        
        [HttpPost] public async Task<IActionResult> Post([FromBody] InsurancePolicyRequest request)
        {
            var customerToCreate = new Customer
            {
                Address = request.CustomerAddress,
                Name = request.CustomerName,
                IdentificationNumber = request.CustomerIdentification,
                BirthDate = request.CustomerBirthDate,
                HomeTown = request.CustomerCity
            };

            var customerResult = await _customerService.CreateAsync(customerToCreate);
            var requestedPolice = await _ownService.GetByIdAsync(request.PolicyIdentifier);
            if (requestedPolice is null)
            {
                return BadRequest(new ResponseResult<string>(false,"No existe un seguro con este número de POLIZA","null",null));
            }
            else if (DateTime.Now.ToUniversalTime() > requestedPolice.Validity.To.ToUniversalTime())
            {
                return BadRequest(new ResponseResult<string>(false, "POLIZA DE SEGURO NO ESTÁ VIGENTE", "null", null));
            }

            var carToAdd = new Car(request.VehicleLicensePlate, request.VehicleModel, request.VehicleInspected);

            var contractToCreate = new ContractInsurancePolicy
            {
                CreateAt = DateTime.UtcNow,
                CustomerUuid = customerResult.Id,
                Vehicle = carToAdd,
                InsurancePolicyIdentifier = request.PolicyIdentifier,
            };

            var contractResult = await _contractService.CreateAsync(contractToCreate);

            if(contractResult is null)
            {
                return BadRequest(new ResponseResult<string>(false, "Ocurrio un error, no pudo ser creada", "null", null));
            }
            return Ok(new ResponseResult<ContractInsurancePolicy>(true, "Poliza creada con exito", contractToCreate, null));
        }
    }
}
