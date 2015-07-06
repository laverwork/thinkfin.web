using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceTest
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class GetCompaniesResponse
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //string r = string.Empty;
            //Task.Run(() => r = this.GetAsync());

            var result = GetAsync();

            var text = result.Result;

            foreach (var company in text.Companies)
            {
               Console.WriteLine(company.Name);
            }
           // Console.WriteLine(text.Companies);
            Console.ReadLine();

        }


        public static async Task<GetCompaniesResponse> GetAsync()
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
                else return null;
            }
        }

    }
}
