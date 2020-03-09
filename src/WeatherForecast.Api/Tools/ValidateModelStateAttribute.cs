using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherForecast.Api.Tools
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public ValidateModelStateAttribute(IValidatorFactory factory) => Factory = factory;

        private IValidatorFactory Factory { get; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            if (actionContext.ActionArguments.Count != actionContext.ActionDescriptor.Parameters.Count)
            {
                throw new ValidationException("Validation exception", new[] { new ValidationFailure("Action arguments not supplied", "Action arguments not supplied") });
            }

            {
                var allErrors = new List<ValidationFailure>();

                foreach (var (_, value) in actionContext.ActionArguments)
                {
                    if (value == default)
                    {
                        continue;
                    }

                    var validator = Factory.GetValidator(value.GetType());

                    if (validator == default)
                    {
                        continue;
                    }

                    var result = await validator.ValidateAsync(value);

                    if (!result.IsValid)
                    {
                        allErrors.AddRange(result.Errors);
                    }
                }

                if (allErrors.Any())
                {
                    throw new ValidationException("Validation exception", allErrors);
                }

                await next.Invoke();
            }
        }
    }
}
