using sureApp.domain.CustomerEntity;
using sureApp.domain.Interfaces.Behaviors;

namespace sureApp.Application.VSCustomer
{
    public interface ICustomerService:ICreateAsync<Customer>,IGetAllAsync<Customer>
    {

    }
}
