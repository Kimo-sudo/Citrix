using Citrix.Models.Models.Klachten;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.Models.Services.DataAccess
{
    public interface IDataAccesUI<T>
    {
        Task<IList<T>> GetAll();

        Task<T> GetManagerById(int id);

        Task<Dagdeel> GetDagmailById(int id);
    }

}
