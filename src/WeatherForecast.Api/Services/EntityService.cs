using System.Threading.Tasks;

using AutoMapper;
using WeatherForecast.Api.Extensions;
using WeatherForecast.Api.Services.Contracts;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Filters;
using WeatherForecast.Core.Paging;
using WeatherForecast.Core.Responses;
using WeatherForecast.Core.Services;
using WeatherForecast.Core.Services.Contracts;
using WeatherForecast.DataAccess.Repositories.Contracts;

namespace WeatherForecast.Api.Services
{
    public class EntityService<TEntity, TResponse>
        : ServiceResponse<TEntity, TResponse>,
          IPagedService<TEntity, TResponse>
        where TEntity : Entity
        where TResponse : ApiResponse<TResponse>
    {
        public EntityService(
            IEntityRepository<TEntity> repository,
            IMapper mapper,
            ApiMapperBase<TEntity, TResponse> responseMapper)
            : base(repository, mapper)
        {
            ResponseMapper = responseMapper;
        }

        private ApiMapperBase<TEntity, TResponse> ResponseMapper { get; }

        public async Task<PagedResponse<TResponse>> GetPagedAsync(AbstractPagingFilter<TEntity> queryExpression) =>
            await Query.ToPagedResultAsync(queryExpression, ResponseMapper.Map);
    }
}
