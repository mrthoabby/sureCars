using sureApp.domain.Interfaces.Behaviors;

namespace sureApp.domain.CustomerEntity
{
    public interface ICustomerRepository:ICreateAsync<Customer>,IGetAllAsync<Customer>,IGetByIdAsync<Customer,string>
    {

    }
}
