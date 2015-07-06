using System.Threading.Tasks;
using MarketData.Query.Contracts;

namespace thinkfin.web.Queries
{
    public interface IGetCompaniesQuery
    {
        Task<GetCompaniesResponse> GetAsync();
    }
}
