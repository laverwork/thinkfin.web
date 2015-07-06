using AutoMapper;
using MarketData.Query.Contracts;
using thinkfin.web.Models;

namespace thinkfin.web.Infrastructure.Mappers
{
    public class CompanyMappingProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Company, CompanyViewModel>();
        }
    }
}