using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HolaMundo.RFC.Models
{
    public class RFCDTO
    {
        [JsonPropertyName("rfc")]
        public string? Rfc { get; set; }

        [JsonPropertyName("fecha")]
        public DateTimeOffset Fecha { get; set; }
    }
}
