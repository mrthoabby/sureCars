using sureApp.domain.ValueObjects;

namespace Domain.InsurancePolicyEntity
{
    public class InsurancePolicy
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateRange Validity { get; set; }
        public double MaximunCoverageValue { get; set; }
        public List<int> FeaturesId { get; set; }
    }
}
