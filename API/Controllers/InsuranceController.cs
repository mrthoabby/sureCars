using Application.VSContractInsurancePolicy;
using Application.VSInsurancePolicy;
using Application.Wrappers;
using Domain.ContractInsurancePolicyEntity;
using Domain.InsurancePolicyEntity;
using Microsoft.AspNetCore.Mvc;
using sureApp.Application.VSCustomer;
using sureApp.domain.CustomerEntity;
using sureApp.domain.ValueObjects;

namespace API.Controllers
{
    /// <summary>
    /// No es ideal que un endpoint controller tenga tanto codigo pero me estoy viendo cogido de tiempo y el codigo escalable es mejorable
    /// Hay codigo repetitivo se debe agrupar a una función pero no lo hago por tiempo
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
            
            var result = await _contractService.GetAllAsync();
            var constract = result.FirstOrDefault(x => x.Vehicle.Plate.ToLower() == plate.ToLower());
            if (constract is null) return BadRequest(new ResponseResult<string>(false, "NOT FOUND", "No data", null));
            var insurances = await _ownService.GetByIdAsync(constract.InsurancePolicyIdentifier);
            var customers = await _customerService.GetByIdAsync(constract.CustomerUuid);

            return Ok(new InsuranceCreatioResult
            {
                PolicyNumberId = constract.Id,
                CustomerName = customers.Name,
                CustomerIdentification = customers.IdentificationNumber,
                CustomerBirthDate = customers.BirthDate,
                createAt = constract.CreateAt,
                CoverageValues = string.Join("-", insurances.FeaturesId),
                MaxCoverageMoney = insurances.MaximunCoverageValue,
                PolicyName = insurances.Name,
                ClientCity = customers.HomeTown,
                ClientAddress = customers.Address,
                VehiclePlate = constract.Vehicle.Plate,
                VehicleModel = constract.Vehicle.Model,
                IsInspectedTheVehicle = constract.Vehicle.IsItInspected
            });

        }
        [HttpGet("policy/{number}")]
        public async Task<IActionResult> Get(int number)
        {

            var result = await _contractService.GetAllAsync();
            var constract = result.FirstOrDefault(x => x.Id == number);
            if (constract is null) return BadRequest(new ResponseResult<string>(false, "NOT FOUND", null, null));
            var insurances = await _ownService.GetByIdAsync(constract.InsurancePolicyIdentifier);
            var customers = await _customerService.GetByIdAsync(constract.CustomerUuid);

            return Ok(new InsuranceCreatioResult
            {
                PolicyNumberId = constract.Id,
                CustomerName = customers.Name,
                CustomerIdentification = customers.IdentificationNumber,
                CustomerBirthDate = customers.BirthDate,
                createAt = constract.CreateAt,
                CoverageValues = string.Join("-", insurances.FeaturesId),
                MaxCoverageMoney = insurances.MaximunCoverageValue,
                PolicyName = insurances.Name,
                ClientCity = customers.HomeTown,
                ClientAddress = customers.Address,
                VehiclePlate = constract.Vehicle.Plate,
                VehicleModel = constract.Vehicle.Model,
                IsInspectedTheVehicle = constract.Vehicle.IsItInspected
            });

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
                return BadRequest(new ResponseResult<InsurancePolicy>(false, "POLIZA DE SEGURO NO ESTÁ VIGENTE", requestedPolice, null));
            }

            var contractToCreate = new ContractInsurancePolicy
            {
                CreateAt = DateTime.UtcNow,
                CustomerUuid = customerResult.Id,
                Vehicle = new Car(request.VehicleLicensePlate, request.VehicleModel, request.VehicleInspected),
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
