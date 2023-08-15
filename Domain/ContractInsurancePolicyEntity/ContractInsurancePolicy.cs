using sureApp.domain.Interfaces;

namespace Domain.ContractInsurancePolicyEntity
{
    public class ContractInsurancePolicy
    {
        public long PolicyContractNumber { get; set; }
        public string InsurancePolicyIdentifier { get; set; }
        public string CustomerUuid { get; set; }
        public DateTime CreateAt { get; set; }
        public IVehicle Vehicle { get; set; }
    }
}
