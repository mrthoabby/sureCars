using sureApp.domain.Interfaces;

namespace Domain.ContractEntity
{
    public class Contract
    {
        public string Id { get; set; }
        public long InsurancePolicyId { get; set; }
        public string CustomerUuid { get; set; }
        public DateTime CreateAt { get; set; }
        public IVehicle Vehicle { get; set; }
    }
}
