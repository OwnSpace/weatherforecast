using System.Linq;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Responses;
using WeatherForecast.DataAccess.Repositories.Contracts;

namespace WeatherForecast.Api.Services.Contracts
{
    public abstract class ServiceBase<TEntity, TResponse>
        where TEntity : Entity, ILifetime
        where TResponse : ApiResponse<TResponse>
    {
        protected ServiceBase(
            IEntityRepository<TEntity> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        protected IEntityRepository<TEntity> Repository { get; }

        protected IMapper Mapper { get; }

        protected virtual IQueryable<TEntity> Query => Repository.Query.AsNoTracking();
    }
}
