using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HolaMundo.RFC.Models
{
    public class SolicitudRFCDTO
    {
        [JsonPropertyName("tipoDePersona")]
        public int TipoDePersona { get; set; } = 0;

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("primerApellido")]
        public string? PrimerApellido { get; set; }

        [JsonPropertyName("segundoApellido")]
        public string? SegundoApellido { get; set; }

        [JsonPropertyName("fechaDeNacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }
    }
}
