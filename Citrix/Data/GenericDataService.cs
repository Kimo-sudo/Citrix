using Citrix.Models.Services.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix.Data
{
    public class GenericDataService<T> : IDataAccesUI<T> where T : class
    {
        private readonly ApplicationDbContextFactory _contextFactory;

        public GenericDataService(ApplicationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IList<T>> GetAll()
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                IList<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

    }
}
    
