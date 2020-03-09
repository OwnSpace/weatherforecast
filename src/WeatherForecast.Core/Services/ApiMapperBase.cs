using System.Collections.Generic;
using System.Linq;

using AutoMapper;

namespace WeatherForecast.Core.Services
{
    public abstract class ApiMapperBase<TIn, TOut>
    {
        protected ApiMapperBase(IMapper mapper) => Mapper = mapper;

        private IMapper Mapper { get; }

        public IEnumerable<TOut> Map(IEnumerable<TIn> @in) =>
            @in == null
                ? Enumerable.Empty<TOut>()
                : @in.Select(Mapper.Map<TIn, TOut>);

        public TOut Map(TIn @in) => Mapper.Map<TOut>(@in);
    }
}
