using System.Text.Json.Serialization;

namespace Wizard.Library.Model
{
    public class WizardComponent
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
