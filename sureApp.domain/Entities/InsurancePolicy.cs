using sureApp.domain.Interfaces;
namespace sureApp.domain.Entities
{
    public class InsurancePolicy
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; } = DateTime.Now;
        public Coverage Coverage { get; set; }
        public List<IVehicle> Vehicles { get; set; }
        public Guid CustomerIdentifier { get; set; }
    }
}
