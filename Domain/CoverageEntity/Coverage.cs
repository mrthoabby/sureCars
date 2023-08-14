using sureApp.domain.ValueObjects;

namespace sureApp.domain.CoverageEntity
{
    public class Coverage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double MaximunCoverageValue { get; set; }
        public DateRange Availability { get; set; }
    }
}
