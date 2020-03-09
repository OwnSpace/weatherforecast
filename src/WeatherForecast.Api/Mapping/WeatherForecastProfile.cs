using AutoMapper;
using WeatherForecast.Api.Resources.Requests;
using WeatherForecast.Api.Resources.Responses;

namespace WeatherForecast.Api.Mapping
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecastRequest, Domain.Models.WeatherForecast>();

            CreateMap<Domain.Models.WeatherForecast, WeatherForecastResponse>()
                .ForMember(dest => dest.Date, opts => opts.MapFrom(o => o.Date))
                .ForMember(dest => dest.MinTemperatureC, opts => opts.MapFrom(o => o.MinTemperature))
                .ForMember(dest => dest.MaxTemperatureC, opts => opts.MapFrom(o => o.MaxTemperature))
                .ForMember(dest => dest.Precipitation, opts => opts.MapFrom(o => o.Precipitation))
                .ForMember(dest => dest.Wind, opts => opts.MapFrom(o => o.Wind))
                .ForMember(dest => dest.Summary, opts => opts.MapFrom(o => o.Summary))
                .ForMember(dest => dest.City, opts => opts.MapFrom(o => o.City));
        }
    }
}
