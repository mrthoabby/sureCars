using sureApp.domain.Interfaces.Behaviors;

namespace Domain.ContractInsurancePolicyEntity
{
    public interface ContractInsurancePolicyRepository: ICreateAsync<ContractInsurancePolicy>, IGetAllAsync<ContractInsurancePolicy>
    {
    }
}
