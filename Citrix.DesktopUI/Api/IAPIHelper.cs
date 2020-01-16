using Citrix.DesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        void LogOffUser();
        Task<UserAuth> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}
