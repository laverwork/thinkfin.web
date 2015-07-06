namespace thinkfin.web.Infrastructure.Mappers
{
    public class Mappers
    {
        public static void Init()
        {
            AutoMapper.Mapper.AddProfile<CompanyMappingProfile>();
        }
    }
}