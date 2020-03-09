using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WeatherForecast.Core.Filters;
using WeatherForecast.Core.Paging;

namespace WeatherForecast.Api.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<TResponse>> ToPagedResultAsync<TSource, TResponse>(
            this IQueryable<TSource> queryable,
            AbstractPagingFilter<TSource> filterRequest,
            Func<IEnumerable<TSource>, IEnumerable<TResponse>> resultMapper)
        {
            var (query, total) = filterRequest.ApplyTo(queryable);
            var data = filterRequest.CountOnly ? Enumerable.Empty<TSource>() : await query.ToListAsync();

            return new PagedResponse<TResponse>(
                await total(),
                filterRequest.PageSize,
                filterRequest.Page,
                resultMapper(data).ToArray());
        }
    }
}
