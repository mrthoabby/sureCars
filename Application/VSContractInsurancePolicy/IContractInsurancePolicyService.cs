using Domain.ContractInsurancePolicyEntity;
using sureApp.domain.Interfaces.Behaviors;

namespace Application.VSContractInsurancePolicy
{
    public interface IContractInsurancePolicyService:ICreateAsync<ContractInsurancePolicy>,IGetAllAsync<ContractInsurancePolicy>
    {
    }
}
