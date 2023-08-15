using Domain.ContractEntity;
using MongoDB.Driver;
using sureApp.Infrastructure;

namespace Infrastructure.ContractSource
{
    internal class ContractRepository : IContractRepository
    {
        private readonly IMongoCollection<Contract> _collection;
        public ContractRepository(ApplicationDbContext context)
        {
            _collection = context.Contracts;
        }
        public async Task<Contract> CreateAsync(Contract entity)
        {
            var filter = Builders<Contract>.Filter.Empty;
            var update = Builders<Contract>.Update.CurrentDate(x => x.CreateAt);
            var options = new FindOneAndUpdateOptions<Contract>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            return await _collection.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<IQueryable<Contract>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }
    }
}
