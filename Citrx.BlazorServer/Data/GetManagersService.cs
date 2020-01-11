using Citrix.Models;
using Citrx.BlazorServer.Data.Database;
using Ctrx.BlazorServer.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ctrx.BlazorServer.Data
{
    public class GetManagersService
    {
        private readonly SqlDbContext _context;

        public GetManagersService(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetManagersAsync()
        {
            return await _context.Manager.ToListAsync();
        }
    }
}
