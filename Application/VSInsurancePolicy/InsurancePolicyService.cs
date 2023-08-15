using Domain.InsurancePolicyEntity;

namespace Application.VSInsurancePolicy
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private IInsurancePolicyRepository _coverageRepository;
        public InsurancePolicyService(IInsurancePolicyRepository coverageRepository)
        {
            _coverageRepository = coverageRepository;
        }

        public Task<InsurancePolicy> CreateAsync(InsurancePolicy entity)
        {
           return _coverageRepository.CreateAsync(entity);
        }

        public async Task<IQueryable<InsurancePolicy>> GetAllAsync()
        {
            return await _coverageRepository.GetAllAsync();
        }

        public async Task<InsurancePolicy> GetByIdAsync(long id)
        {
            return await _coverageRepository.GetByIdAsync(id);
        }
    }
}
