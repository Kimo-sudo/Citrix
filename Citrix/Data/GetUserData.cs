using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix.Data
{
    public class GetUserData : IGetUserData
    {
        private readonly ApplicationDbContext _context;

        public GetUserData(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Roles> GetAllUsers()
        {
            List<Roles> output = new List<Roles>();
            using (_context)
            {
                var userStore = new GetUserData(_context);
                var userManager = new GetUserData(_context);

                var users = userStore._context.Users.ToList();
                var roles = _context.UserRoles.ToList();

                foreach (var user in users)
                {
                    Roles u = new Roles
                    {
                        ID = user.Id,
                        Functie = user.Email
                    };

                    output.Add(u);
                }
                return output;
            }
        }
    }
}