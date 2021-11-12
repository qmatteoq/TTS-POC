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
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = false, Type = typeof(string), Summary = "The form type", Description = "The form type")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(WizardForm), Description = "The wizard form")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Form/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            WizardForm form;

            switch (id)
            {
                case "customer":
                    form = GenerateCustomerForm();
                    break;
                case "order":
                    form = GenerateOrderForm();
                    break;
                default:
                    form = GenerateCustomerForm();
                    break;
            }

           

            var jsonString = WizardFormSerializer.Serialize(form);
    
            return new OkObjectResult(jsonString);
        }

        private static WizardForm GenerateOrderForm()
        {
            WizardForm form = new WizardForm
            {
                Title = "New order",
                Components = new List<WizardComponent>
                {
                    new WizardComponent { Label = "Insert the name of the product:", Type = WizardComponentType.Text, FieldName = "Product"},
                    new WizardComponent { Label = "Insert the total price:", Type = WizardComponentType.Number, FieldName = "Total"},
                    new WizardComponent { Label = "Inser the order's date:", Type = WizardComponentType.Date, FieldName = "OrderDate"}
                }
            };

            return form;
        }

        private static WizardForm GenerateCustomerForm()
        {
            WizardForm form = new WizardForm
            {
                Title = "New customer",
                Components = new List<WizardComponent>
                {
                    new WizardComponent { Label = "Insert your name:", Type = WizardComponentType.Text, FieldName = "Name" },
                    new WizardComponent { Label = "Insert your surname: ", Type = WizardComponentType.Text, FieldName = "Surname"},
                    new WizardComponent { Label = "Insert your age: ", Type = WizardComponentType.Number, FieldName = "Age"},
                    new WizardComponent { Label = "Choose your birth date: ", Type = WizardComponentType.Date, FieldName = "BirthDate"}
                }
            };

            return form;
        }
    }
}

