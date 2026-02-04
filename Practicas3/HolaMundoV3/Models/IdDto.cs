using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HolaMundo.Models
{
    public class IdDto
    {
        [JsonPropertyName("encodedkey")]
        public Guid EncodedKey { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fecha")]
        public DateTimeOffset Fecha { get; set; }
    }
}
