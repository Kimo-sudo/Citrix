using Citrix.DesktopUI.Lib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.lib
{
    public class DagmailEndpoint : IDagmailEndpoint
    {
        private IAPIHelper _api;

        public DagmailEndpoint(IAPIHelper api)
        {
            _api = api;
        }

        public async Task<List<Dagmail>> GetAll()
        {
            using (HttpResponseMessage response = await _api.ApiClient.GetAsync("/api/Dagdeel"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Dagmail>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
