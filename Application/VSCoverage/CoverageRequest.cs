using sureApp.domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Application.VSCoverage
{
    public class CoverageRequest
    {
        [JsonPropertyName("Nombre")]
        public string Name { get; set; }
        [JsonPropertyName("Disponibilidad")]
        public DateRange Availability { get; set; }
        [JsonPropertyName("Monto")]
        public double MaximunCoverageValue { get; set; }
    }
}
