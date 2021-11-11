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
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(WizardForm), Description = "The wizard form")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            WizardForm form = new WizardForm
            {
                Title = "This is my form",
                Components = new List<WizardComponent>
                {
                    new WizardComponent { Label = "Name", Type = "textblock" },
                    new WizardComponent { Label = "Name", Type = "textbox" },
                    new WizardComponent { Label = "Button", Type = "button" }
                }
            };

            return new OkObjectResult(form);
        }
    }
}

