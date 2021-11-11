using System.Text.Json;
using System.Text.Json.Serialization;

namespace Wizard.Library.Model
{
    public static class WizardFormSerializer
    {
        private static JsonSerializerOptions options;

        static WizardFormSerializer() 
        {
            options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
        }

        public static string Serialize<T>(T form)
        {
            return JsonSerializer.Serialize(form, options);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
