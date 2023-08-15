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

        public Task<InsurancePolicy> GetByCustomDataSearcher(string data)
        {
            throw new NotImplementedException();
        }

        public async Task<InsurancePolicy> GetByIdAsync(string id)
        {
            return await _coverageRepository.GetByIdAsync(id);
        }
    }
}
