namespace thinkfin.web.Infrastructure.Mappers
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }

    public interface IMapper<in TSource, out TDestination>
    {
        TDestination Map(TSource source);
    }

    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}