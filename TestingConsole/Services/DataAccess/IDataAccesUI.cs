using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.Models.Services.DataAccess
{
    public interface IDataAccesUI<T>
    {
        Task<IEnumerable<T>> GetAll();
    }

}
