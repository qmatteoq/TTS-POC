using System.Text.Json.Serialization;

namespace Wizard.Library.Model
{
    public class WizardComponent
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("fieldName")]
        public string FieldName { get; set; }

        [JsonPropertyName("type")]
        public WizardComponentType Type { get; set; }
    }
}
