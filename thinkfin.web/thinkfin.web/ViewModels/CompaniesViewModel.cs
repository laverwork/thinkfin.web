using System.Collections.Generic;
using thinkfin.web.Models;

namespace thinkfin.web.ViewModels
{
    public class CompaniesViewModel
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}