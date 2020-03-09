using AutoMapper;
using WeatherForecast.Core.Requests;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Core.Services
{
    public class RequestMapper<TRequest, TEntity>
        : ApiMapperBase<TRequest, TEntity>,
          IRequestMapper<TRequest, TEntity>
        where TRequest : ApiRequest<TRequest>
    {
        public RequestMapper(IMapper mapper)
            : base(mapper)
        {
        }
    }
}
