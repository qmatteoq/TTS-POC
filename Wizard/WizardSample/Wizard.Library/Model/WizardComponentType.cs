using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Wizard.Library.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WizardComponentType
    {
        TextBlock,
        TextBox,
        Button
    }
}
