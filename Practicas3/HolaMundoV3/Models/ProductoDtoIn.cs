using System;
using System.Text.Json.Serialization;

namespace HolaMundo.Models
{
    public class ProductoDtoIn
    {
        [JsonPropertyName("encodedkey")]
        public Guid? EncodedKey { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }

        [JsonPropertyName("imagenUrl")]
        public string imagenUrl { get; set; }
    }
}
