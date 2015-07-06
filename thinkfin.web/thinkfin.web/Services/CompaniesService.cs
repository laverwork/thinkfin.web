using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketData.Query.Contracts;
using thinkfin.web.Infrastructure.Caching;
using thinkfin.web.Infrastructure.Mappers;
using thinkfin.web.Models;
using thinkfin.web.Queries;

namespace thinkfin.web.Services
{

    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyViewModel>> GetAsync();
    }

    public class CompaniesService : ICompaniesService
    {
        private readonly IGetCompaniesQuery _getCompaniesQuery;
        private readonly IMapper _mapper;
        private readonly ICache _cache;
        static private readonly object CacheLock = new object();
        private const int CacheMinutes = 10;
        private const string CacheKey = "companies";

        public CompaniesService(IGetCompaniesQuery getCompaniesQuery, IMapper mapper, ICache cache)
        {
            _getCompaniesQuery = getCompaniesQuery;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAsync()
        {
            var companies = await Task.Run(() =>
               _cache.RetreiveFromCache(CacheLock, CacheKey, DateTime.Now.AddMinutes(CacheMinutes),
                   () => _getCompaniesQuery.GetAsync()));
            
            return companies.Companies.ToList().Select(x => _mapper.Map<Company, CompanyViewModel>(x));
        } 
    }
}