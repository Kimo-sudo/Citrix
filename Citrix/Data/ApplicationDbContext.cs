using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Citrix.Models;
using Microsoft.AspNetCore.Authorization;
using Citrix.Models.Models.Restaurant;
using Citrix.Models.Models.Klachten;

namespace Citrix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ZiekModel> ZiekModel { get; set; }
        public DbSet<Dagdeel> Dagdeel { get; set; }

        public DbSet<KlachtModel> Klacht { get; set; }

        public DbSet<RestaurantModel> Restaurant { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

    }
}