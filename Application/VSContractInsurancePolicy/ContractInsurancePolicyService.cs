using Domain.ContractInsurancePolicyEntity;

namespace Application.VSContractInsurancePolicy
{
    public class ContractInsurancePolicyService : IContractInsurancePolicyService
    {
        private readonly ContractInsurancePolicyRepository _repository;

        public ContractInsurancePolicyService(ContractInsurancePolicyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ContractInsurancePolicy> CreateAsync(ContractInsurancePolicy entity)
        {

            return await _repository.CreateAsync(entity);
        }

        public async Task<IQueryable<ContractInsurancePolicy>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
