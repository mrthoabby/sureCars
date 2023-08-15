using Domain.InsurancePolicyEntity;
using Infrastructure.Helpers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sureApp.Infrastructure.InsurancePolicySource
{
    internal sealed class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly IMongoCollection<InsurancePolicy> _collection;
        private readonly CreateAutoincrementalEntitys _autoIncrementer;
        public InsurancePolicyRepository(ApplicationDbContext context, CreateAutoincrementalEntitys autoIncrementer)
        {
            _collection = context.Coverages;
            _autoIncrementer = autoIncrementer; 
        }

        public async Task<InsurancePolicy> CreateAsync(InsurancePolicy entity)
        {
            return await _autoIncrementer.CreateWithAutoIncrementId(entity, _collection);
        }

        public async Task<IQueryable<InsurancePolicy>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }

        public async Task<InsurancePolicy> GetByIdAsync(string id)
        {
            var data = _collection.AsQueryable();
            return await data.FirstOrDefaultAsync(x => x.Identifier == id);
        }
    }
}
