using Citrix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix.Client.Data
{
    public class ManagerService
    {
        private readonly ApplicationDbContext _context;

        public IList<Manager> Managers { get; set; }

        public ManagerService(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<IList<Manager>> GetAllManagers()
        {
            Managers = await _context.Manager.ToListAsync();
            return Managers;

        }
    }
}
