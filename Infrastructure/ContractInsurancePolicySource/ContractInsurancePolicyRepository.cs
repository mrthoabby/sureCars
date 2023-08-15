using Domain.ContractInsurancePolicyEntity;
using Infrastructure.Helpers;
using MongoDB.Driver;
using sureApp.Infrastructure;

namespace Infrastructure.ContractInsurancePolicySource
{
    internal class ContractInsurancePolicyRepository :IContractInsurancePolicyRepository
    {
        private readonly IMongoCollection<ContractInsurancePolicy> _collection;
        private readonly CreateAutoincrementalEntitys _autoIncrementer;
        public ContractInsurancePolicyRepository(ApplicationDbContext context, CreateAutoincrementalEntitys autoIncrementer)
        {
            _collection = context.Contracts;
            _autoIncrementer = autoIncrementer;
        }
        public async Task<ContractInsurancePolicy> CreateAsync(ContractInsurancePolicy entity)
        {
            return await _autoIncrementer.CreateWithAutoIncrementId(entity, _collection);
        }
        public async Task<IQueryable<ContractInsurancePolicy>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }
    }
}
