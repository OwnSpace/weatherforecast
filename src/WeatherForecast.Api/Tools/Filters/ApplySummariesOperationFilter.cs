using System.Linq;

using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WeatherForecast.Api.Tools.Filters
{
    public sealed class ApplySummariesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!(context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor))
            {
                return;
            }

            var actionName = controllerActionDescriptor.ActionName.ToUpperInvariant();
            var resourceName = Depluralize(controllerActionDescriptor.ControllerName);

            switch (actionName)
            {
                case "POST":
                    operation.Summary = $"Creates a {resourceName}";

                    break;
                case "GET":
                    operation.Summary = controllerActionDescriptor.Parameters.Any(p => p.Name == "id")
                        ? $"Retrieves a {resourceName} by unique id"
                        : $"Returns paged list of {Pluralize(resourceName)}";
                    break;
                case "PUT":
                    operation.Summary = $"Updates a {resourceName} by unique id";
                    operation.Parameters[0].Description = $"a unique id of the {resourceName}";

                    break;
                case "DELETE":
                    operation.Summary =
                        operation.Parameters.Any(p => p.Name == "id")
                            ? $"Deletes a {resourceName} by unique id"
                            : $"Deletes a {resourceName} by request";

                    break;
            }
        }

        private static string Pluralize(string s) => s.EndsWith("y") ? s[..^1] + "ies" : s + "s";

        private static string Depluralize(string s) => s.EndsWith("ies") ? s[..^3] + "y" : s.TrimEnd('s');
    }
}
