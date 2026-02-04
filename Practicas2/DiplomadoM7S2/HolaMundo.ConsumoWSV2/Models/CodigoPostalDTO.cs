using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HolaMundo.ConsumoWSV2.Models
{
    public class CodigoPostalDTO
    {
        [JsonPropertyName("CodigoPostal")]
        public string CodigoPostal { get; set; } = string.Empty;
        [JsonPropertyName("AlcaldiaId")]
        public int AlcaldiaId { get; set; }
        [JsonPropertyName("Estado")]
        public string Estado { get; set; } = string.Empty;
        [JsonPropertyName("EstadoId")]
        public int EstadoId { get; set; }
        [JsonPropertyName("Alcaldia")]
        public string Alcaldia { get; set; } = string.Empty;
        [JsonPropertyName("TipoDeAsentamiento")]
        public string TipoDeAsentamiento { get; set; } = string.Empty;
        [JsonPropertyName("Asentamiento")]
        public string Asentamiento { get; set; } = string.Empty;
    }
}
