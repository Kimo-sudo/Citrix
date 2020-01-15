using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Citrix.Models.Models;

namespace Citrix.EntityFrameWork
{
    public class CitrixDbContext : DbContext
    {
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ZiekModel> ZiekModel { get; set; }
        public DbSet<Dagdeel> Dagdeel { get; set; }

        public DbSet<KlachtModel> Klacht { get; set; }

        public DbSet<RestaurantModel> Restaurant { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
