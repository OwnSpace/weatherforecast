using AutoMapper;
using WeatherForecast.Api.Resources.Requests;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Api.Mapping
{
    public sealed class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityRequest, City>();

            CreateMap<City, CityResponse>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(o => o.Id))
                .ForMember(dest => dest.Code, opts => opts.MapFrom(o => o.IATA))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(o => o.Name))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(o => o.Country));
        }
    }
}
