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

        public Task<Customer> CreateAsync(Customer entity)
        {
            return _repository.CreateAsync(entity);
        }
    }
}
