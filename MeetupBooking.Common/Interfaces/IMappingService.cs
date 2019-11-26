namespace MeetupBooking.Common.Interfaces
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
