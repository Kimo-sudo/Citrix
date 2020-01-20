using Citrix.DesktopUI.Lib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.lib
{
    public interface IKlachtenEndpoint
    {
        Task<List<KlachtModel>> GetAll();
    }
}