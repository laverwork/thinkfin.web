using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketData.Query.Contracts;

namespace thinkfin.web.Queries
{
    public class GetCompaniesQuery : IGetCompaniesQuery
    {
        public async Task<GetCompaniesResponse> GetAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:222/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("companies");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<GetCompaniesResponse>();
                }

                return null;
            }
        }
    }
}