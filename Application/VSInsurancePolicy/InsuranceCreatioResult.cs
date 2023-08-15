using System.Text.Json.Serialization;

namespace Application.VSInsurancePolicy
{
    public class InsuranceCreatioResult
    {
        [JsonPropertyName("# de poliza")]
        public long PolicyNumberId { get; set; }
        [JsonPropertyName("Nombre Cliente")]
        public string CustomerName { get; set; }
        [JsonPropertyName("Identificación del cliente")]
        public string CustomerIdentification { get; set; }
        [JsonPropertyName("Fecha de nacimiento del cliente")]
        public DateTime CustomerBirthDate { get; set; }
        [JsonPropertyName("Fecha en que se tomó la poliza")]
        public DateTime createAt { get; set; }
        [JsonPropertyName("Coverturas cubiertas por la poliza")]
        public List<string> CoverageValues { get; set; }
        [JsonPropertyName("Valor maximo cubierto por la póliza")]
        public double MaxCoverageMoney { get; set; }
        [JsonPropertyName("Nombre del plan de la póliza")]
        public string PolicyName { get; set; }
        [JsonPropertyName("Ciudad de residencia del cliente")]
        public string ClientCity { get; set; }
        [JsonPropertyName("Dirección de residencia del cliente")]
        public string ClientAddress { get; set; }
        [JsonPropertyName("Placa del automotor")]
        public string VehiclePlate { get; set; }
        [JsonPropertyName("Modelo del automotor")]
        public string VehicleModel { get; set; }
        [JsonPropertyName("¿El vehiculo tiene inspección?")]
        public bool IsInspectedTheVehicle { get; set; }
    }
}
