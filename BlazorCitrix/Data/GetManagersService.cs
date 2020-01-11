using BlazorCitrix.Data.Base;
using Citrix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCitrix.Data
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
