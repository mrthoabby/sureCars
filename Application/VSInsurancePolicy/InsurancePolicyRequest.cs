using System.Text.Json.Serialization;

namespace Application.VSInsurancePolicy
{
    //No es recomendado utilizar tildes pero limito a cumplir las reglase del negocio
    public class InsurancePolicyRequest
    {
        [JsonPropertyName("Poliza_requerida_Identificador")]
        public string PolicyIdentifier { get; set; }
        [JsonPropertyName("Nombre_Cliente")]
        public string CustomerName { get; set; }
        [JsonPropertyName("Identificacion_Cliente")]
        public string CustomerIdentification { get; set; }
        [JsonPropertyName("Cumpleaños_cliente")]
        public DateTime CustomerBirthDate { get; set; }
        [JsonPropertyName("Ciudad_cliente")]
        public string CustomerCity { get; set; }
        [JsonPropertyName("Direccion_cliente")]
        public string CustomerAddress { get; set; }
        [JsonPropertyName("Placa_auto")]
        public string VehicleLicensePlate { get; set; }
        [JsonPropertyName("Modelo_auto")]
        public string VehicleModel { get; set; }
        [JsonPropertyName("Auto_Inspeccionado")]
        public bool VehicleInspected { get; set; }
    }
}
