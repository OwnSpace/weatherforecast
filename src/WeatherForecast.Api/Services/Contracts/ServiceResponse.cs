using AutoMapper;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Responses;
using WeatherForecast.DataAccess.Repositories.Contracts;

namespace WeatherForecast.Api.Services.Contracts
{
    public abstract class ServiceResponse<TEntity, TResponse> : ServiceBase<TEntity, TResponse>
        where TEntity : Entity, ILifetime
        where TResponse : ApiResponse<TResponse>
    {
        protected ServiceResponse(
            IEntityRepository<TEntity> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }

        protected Response<TResponse> Success(TEntity entity) => Response<TResponse>.SuccessResponse(Mapper.Map<TResponse>(entity));
    }
}
