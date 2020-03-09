using AutoMapper;
using WeatherForecast.Api.Resources.Requests;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Api.Mapping
{
    public sealed class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryRequest, Country>();

            CreateMap<Country, CountryResponse>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(o => o.Name));
        }
    }
}
