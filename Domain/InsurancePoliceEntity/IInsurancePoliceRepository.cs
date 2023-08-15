using sureApp.domain.Interfaces.Behaviors;

namespace Domain.InsurancePolicyEntity
{
    public interface IInsurancePolicyRepository : ICreateAsync<InsurancePolicy>, IGetAllAsync<InsurancePolicy>,IGetByIdAsync<InsurancePolicy,string>
    {
    }
}
