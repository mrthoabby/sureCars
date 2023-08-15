using Domain.InsurancePolicyEntity;
using sureApp.domain.Interfaces.Behaviors;

namespace Application.VSInsurancePolicy
{
    public interface IInsurancePolicyService : IGetAllAsync<InsurancePolicy>,ICreateAsync<InsurancePolicy>,IGetByIdAsync<InsurancePolicy,long>
    {
    }
}
