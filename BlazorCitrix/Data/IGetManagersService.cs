using Citrix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCitrix.Data
{
    public interface IGetManagersService
    {
        Task<List<Manager>> GetManagersAsync();
        Task<List<Manager>> GetManagersOnRestAsync(int restaurant);
    }
}