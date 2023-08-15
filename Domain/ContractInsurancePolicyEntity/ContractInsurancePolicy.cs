using sureApp.domain.ValueObjects;

namespace Domain.ContractInsurancePolicyEntity
{
    public class ContractInsurancePolicy
    {
        public int Id { get; set; }
        public string InsurancePolicyIdentifier { get; set; }
        public string CustomerUuid { get; set; }
        public DateTime CreateAt { get; set; }
        public Car Vehicle { get; set; }
    }
}
