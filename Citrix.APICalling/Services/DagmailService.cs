using Citrix.Models;
using Citrix.Models.Models;
using Citrix.Models.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.APICalling.Services
{
    public class DagmailService : IDagmailService
    {
        public async Task<Dagmail> GetDagmail(DagmailOmzet dagmailOmzet)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44310/api/dagdeel/2016");
                string JsonResponse = await response.Content.ReadAsStringAsync();

                Dagmail Dagmails = JsonConvert.DeserializeObject<Dagmail>(JsonResponse);
                return Dagmails;
            }
        }
    }
}
