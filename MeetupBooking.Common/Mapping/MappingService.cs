using AutoMapper;
using MeetupBooking.Common.Interfaces;

namespace MeetupBooking.Common.Mapping
{
    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;

        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            var sourceType = source.GetType();
            var destinationType = typeof(TDestination);

            var destination = (TDestination)_mapper.Map(source, sourceType, destinationType);

            return destination;
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
