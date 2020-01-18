using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer("Data Source=DESKTOP-OISNHO6; Database=CitrixData; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new ApplicationDbContext(options.Options);
        }

        internal object Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}

