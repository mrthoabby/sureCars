
namespace sureApp.domain.Entities.DTO
{
    internal class PolicyCarCreatorFromNewCustomerDTO
    {
        public CustomerDTO Customer { get; set; }
        public CarDTO Car { get; set; }
        public CoverageDTO Coverage { get; set; }
    }
}
