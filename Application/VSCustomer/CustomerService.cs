using sureApp.domain.CustomerEntity;

namespace sureApp.Application.VSCustomer
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> CreateAsync(Customer entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
