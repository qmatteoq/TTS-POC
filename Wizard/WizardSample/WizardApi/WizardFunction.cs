using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Wizard.Library.Model;

namespace WizardApi
{
    public static class WizardFunction
    {
        [FunctionName("WizardFunction")]
        [OpenApiOperation(operationId: "GetWizardForm", tags: new[] { "wizard" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(WizardForm), Description = "The wizard form")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "form")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            WizardForm form = new WizardForm
            {
                Title = "This is my form",
                Components = new List<WizardComponent>
                {
                    new WizardComponent { Label = "Insert your name:", Type = WizardComponentType.Text, FieldName = "Name" },
                    new WizardComponent { Label = "Insert your surname: ", Type = WizardComponentType.Text, FieldName = "Surname"},
                    new WizardComponent { Label = "Insert your age: ", Type = WizardComponentType.Number, FieldName = "Age"},
                    new WizardComponent { Label = "Choose your birth date: ", Type = WizardComponentType.Date, FieldName = "BirthDate"}
                }
            };

            var jsonString = WizardFormSerializer.Serialize(form);
    
            return new OkObjectResult(jsonString);
        }
    }
}

