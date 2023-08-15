using sureApp.domain.Interfaces.Behaviors;

namespace Domain.ContractEntity
{
    public interface IContractRepository: ICreateAsync<Contract>, IGetAllAsync<Contract>
    {
    }
}
