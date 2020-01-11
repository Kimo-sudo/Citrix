using Citrix.Models;
using System.Collections.Generic;

namespace Citrix.Data
{
    public interface IGetUserData
    {
        List<Roles> GetAllUsers();
    }
}