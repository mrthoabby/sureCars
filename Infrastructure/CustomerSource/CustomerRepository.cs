using MongoDB.Driver;
using sureApp.domain.CustomerEntity;
using sureApp.Infrastructure;

namespace Infrastructure.CustomerSource
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;
        public CustomerRepository(ApplicationDbContext context)
        {
            _collection = context.Customers;
        }
        public async Task<Customer> CreateAsync(Customer entity)
        {
            var filter = Builders<Customer>.Filter.Empty;
            var update = Builders<Customer>.Update.CurrentDate(x => x.BirthDate);
            var options = new FindOneAndUpdateOptions<Customer>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            return await _collection.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }
    }
}
