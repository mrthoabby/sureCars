using Domain.ContractInsurancePolicyEntity;
using MongoDB.Driver;
using sureApp.Infrastructure;

namespace Infrastructure.ContractInsurancePolicySource
{
    internal class ContractInsurancePolicyRepository : Domain.ContractInsurancePolicyEntity.ContractInsurancePolicyRepository
    {
        private readonly IMongoCollection<ContractInsurancePolicy> _collection;
        public ContractInsurancePolicyRepository(ApplicationDbContext context)
        {
            _collection = context.Contracts;
        }
        public async Task<ContractInsurancePolicy> CreateAsync(ContractInsurancePolicy entity)
        {
            var filter = Builders<ContractInsurancePolicy>.Filter.Empty;
            var update = Builders<ContractInsurancePolicy>.Update.CurrentDate(x => x.CreateAt);
            var options = new FindOneAndUpdateOptions<ContractInsurancePolicy>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            return await _collection.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<IQueryable<ContractInsurancePolicy>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }
    }
}
