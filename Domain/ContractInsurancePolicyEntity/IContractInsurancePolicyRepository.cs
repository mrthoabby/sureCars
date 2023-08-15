using sureApp.domain.Interfaces.Behaviors;

namespace Domain.ContractInsurancePolicyEntity
{
    public interface IContractInsurancePolicyRepository: ICreateAsync<ContractInsurancePolicy>, IGetAllAsync<ContractInsurancePolicy>
    {
    }
}
