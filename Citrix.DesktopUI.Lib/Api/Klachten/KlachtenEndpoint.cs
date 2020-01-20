using Citrix.DesktopUI.Lib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.lib
{
    public class KlachtenEndpoint : IKlachtenEndpoint
    {
        private IAPIHelper _api;

        public KlachtenEndpoint(IAPIHelper api)
        {
            _api = api;
        }
        public async Task<List<KlachtModel>> GetAll()
        {
            using (HttpResponseMessage response = await _api.ApiClient.GetAsync("/api/klachtmodel")) 
            {

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<KlachtModel>>();
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

