using System.Text.Json.Serialization;

namespace Application.VSInsurancePolicy
{
    //No es recomendado utilizar tildes pero limito a cumplir las reglase del negocio
    public class InsurancePolicyRequest
    {
        [JsonPropertyName("Número de poliza")]
        public long PolicyNumberId { get; set; }
        [JsonPropertyName("Nombre de Cliente")]
        public string CustomerName { get; set; }
        [JsonPropertyName("Número de identificación")]
        public string CustomerIdentification { get; set; }
        [JsonPropertyName("Cumpleaños del cliente")]
        public DateTime CustomerBirthDate { get; set; }
        [JsonPropertyName("Valor maximo cubierto por la poliza")]
        public double MaxCoverageValue { get; set; }
        [JsonPropertyName("Ciudad de residencia del cliente")]
        public string CustomerCity { get; set; }
        [JsonPropertyName("Dirección de residencia del cliente")]
        public string CustomerAddress { get; set; }
        [JsonPropertyName("Placa del vehiculo")]
        public string VehicleLicensePlate { get; set; }
        [JsonPropertyName("Modelo del vehiculo")]
        public string VehicleModel { get; set; }
        [JsonPropertyName("Está inspeccionado del vehiculo")]
        public bool VehicleInspected { get; set; }
    }
}
