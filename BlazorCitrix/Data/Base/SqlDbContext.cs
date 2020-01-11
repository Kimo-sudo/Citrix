using Citrix.Models;
using Citrix.Models.Models.Restaurant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCitrix.Data.Base
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
        {
        }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ZiekModel> ZiekModel { get; set; }
        public DbSet<Dagdeel> Dagdeel { get; set; }
        public DbSet<RestaurantModel> Restaurant { get; set; }

    }
}
