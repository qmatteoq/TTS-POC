using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Wizard.Library.Model
{
    public class WizardForm
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("components")]
        public List<WizardComponent> Components { get; set; }
    }
}
