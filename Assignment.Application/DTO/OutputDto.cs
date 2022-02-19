using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Assignment.Application.DTO
{
    public partial class OutputDto
    {
        [JsonPropertyName("Ordinal")]
        public int Ordinal { get; set; }
        [JsonPropertyName("Value")]
        public string Value { get; set; }

    }
}
