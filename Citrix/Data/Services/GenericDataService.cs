using Citrix.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix.Data.Services
{
    public class GenericDataService<T> : IDataService<T> where T : HoofdObject
    {
        private readonly ApplicationDbContextFactory _contextFactory;

        public GenericDataService(ApplicationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
        public async Task<T> Get(int id)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }
        public async Task<T> Update(int id, T entity)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}