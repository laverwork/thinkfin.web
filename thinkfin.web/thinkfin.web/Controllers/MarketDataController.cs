using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using thinkfin.web.Models;
using thinkfin.web.Services;

namespace thinkfin.web.Controllers
{
    public class MarketDataController : ApiController
    {
        private readonly ICompaniesService _companiesService;

        public MarketDataController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
            //_companiesService = companiesService;
        }

        public Task<IEnumerable<CompanyViewModel>> Get()
        {
            //var companiesService = new CompaniesService();

          //  return companiesService.

            return _companiesService.GetAsync();

            //return new List<CompanyViewModel>()
            //{
            //        new CompanyViewModel()
            //        {
            //            Code = "aaa",
            //            Id = new Guid("9A32FDF0-14EE-459D-AD96-50C6FF78169E"),
            //            Name = "Matt test"
            //        }
            //};
        }
    }
}
