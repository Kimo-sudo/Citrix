using Citrix.DesktopUI.Lib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.lib
{
    public interface IDagmailEndpoint
    {
        Task<List<Dagmail>> GetAll();
    }
}