using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Citrix.DesktopUI.lib
{
     public class APIHelper : IAPIHelper
        {
            private HttpClient _apiClient;
            private ILoggedInUserModel _loggedInUserModel;
            public APIHelper(ILoggedInUserModel loggedInUserModel)
            {
                 InitializeClient();
                _loggedInUserModel = loggedInUserModel;
            }

            public HttpClient ApiClient
            {
                get
                {
                    return _apiClient;
                }
            }

            private void InitializeClient()
            {
                _apiClient = new HttpClient();
                _apiClient.BaseAddress = new Uri($"https://localhost:44310/");
                _apiClient.DefaultRequestHeaders.Accept.Clear();
                _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

        public async Task<UserAuth> Authenticate(string username, string password)
            {
            
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            }          
            );
            var x = await data.ReadAsStringAsync();


            using (HttpResponseMessage response = await _apiClient.PostAsync("/token?" + x, data)) 
            {

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    UserAuth authenticatedUser = JsonConvert.DeserializeObject<UserAuth>(result);
                    return authenticatedUser;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public void LogOffUser()
            {
                _apiClient.DefaultRequestHeaders.Clear();
            }
    }
    }
