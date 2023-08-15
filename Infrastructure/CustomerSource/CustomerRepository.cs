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
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return _collection.AsQueryable();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            var data = _collection.AsQueryable().Where(x => x.Id == id);
            return data.FirstOrDefault();
        }
    }
}
