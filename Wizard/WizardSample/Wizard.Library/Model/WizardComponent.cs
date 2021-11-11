﻿using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Wizard.Library.Model
{
    public class WizardComponent
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WizardComponentType Type { get; set; }
    }
}
