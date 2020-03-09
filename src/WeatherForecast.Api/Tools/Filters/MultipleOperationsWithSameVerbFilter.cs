using System.Linq;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WeatherForecast.Api.Tools.Filters
{
    /// <summary>
    /// Allow multiple operations with same verb filter
    /// </summary>
    public sealed class MultipleOperationsWithSameVerbFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters?.Any() == true)
            {
                operation.OperationId += "_By_" + string.Join("_", operation.Parameters.Select(p => p.Name));
            }
        }
    }
}
