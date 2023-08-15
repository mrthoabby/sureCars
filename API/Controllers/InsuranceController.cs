using Application.VSContract;
using Application.VSInsurancePolicy;
using Application.Wrappers;
using Domain.ContractEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using sureApp.Application.VSCustomer;
using sureApp.domain.CustomerEntity;
using sureApp.domain.ValueObjects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsurancePolicyService _ownService;
        private readonly ICustomerService _customerService;
        private readonly IContractService _contractService;
        public InsuranceController(IInsurancePolicyService services, ICustomerService customer,IContractService contract) {
            _ownService = services;
            _customerService = customer;
            _contractService = contract;
        }

        /// <summary>
        /// No es ideal que un controller tenga tanto codigo pero me estoy viendo cogido de tiempo y el codigo escalable es mejorable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
            var requestedPolice = await _ownService.GetByIdAsync(request.PolicyNumberId);
            if (requestedPolice is null || customerResult is null)
            {
                return BadRequest(new ResponseResult<string>(false,"No existe un seguro con este número de POLIZA","null",null));
            }
            else if (requestedPolice.Validity.To < DateTime.Now)
            {
                return BadRequest(new ResponseResult<string>(false, "POLIZA DE SEGURO NO ESTÁ VIGENTE", "null", null));
            }

            var carToAdd = new Car(request.VehicleLicensePlate, request.VehicleModel, request.VehicleInspected);

            var contractToCreate = new Contract
            {
                CreateAt = DateTime.UtcNow,
                CustomerUuid = customerResult.Id,
                Vehicle = carToAdd,
                InsurancePolicyId = request.PolicyNumberId,
            };

            var contractResult = await _contractService.CreateAsync(contractToCreate);

            if(contractResult is null)
            {
                return BadRequest(new ResponseResult<string>(false, "Ocurrio un error, no pudo ser creada", "null", null));
            }
            return Ok(new ResponseResult<Contract>(false, "Poliza creada con exito", contractToCreate, null));
        }
    }
}
