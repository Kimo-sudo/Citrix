using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citrix.Data.Services
{
    public interface IDataService<T>
    {
        Task<T> Create(T entity);
        Task<bool> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(int id, T entity);
    }
}