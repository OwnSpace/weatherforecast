using System.Collections.Generic;
using System.Linq.Expressions;

namespace WeatherForecast.Core.Tools
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map) =>
            Map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();

        private Dictionary<ParameterExpression, ParameterExpression> Map { get; }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) =>
            new ParameterRebinder(map).Visit(exp);

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (Map.TryGetValue(p, out var replacement) && replacement != default)
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }
    }
}
