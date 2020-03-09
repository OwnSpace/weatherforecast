using AutoMapper;
using WeatherForecast.Core.Responses;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Core.Services
{
    public class ResponseMapper<TEntity, TResponse>
        : ApiMapperBase<TEntity, TResponse>,
          IResponseMapper<TEntity, TResponse>
        where TResponse : ApiResponse<TResponse>
    {
        public ResponseMapper(IMapper mapper)
            : base(mapper)
        {
        }
    }
}
