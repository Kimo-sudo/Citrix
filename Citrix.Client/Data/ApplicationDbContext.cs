using System;
using System.Collections.Generic;
using System.Text;
using Citrix.Models;
using Citrix.Models.Models.Restaurant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Citrix.Client.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ZiekModel> ZiekModel { get; set; }
        public DbSet<Dagdeel> Dagdeel { get; set; }

        public DbSet<RestaurantModel> Restaurant { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
