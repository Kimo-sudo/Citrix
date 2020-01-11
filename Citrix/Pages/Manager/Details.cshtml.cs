using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;
using Citrix.Models.Models.Restaurant;

namespace Citrix
{
    public class DetailsModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public DetailsModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Manager Manager { get; set; }
        [BindProperty]
        public RestaurantModel Restaurant { get; set; }
        [BindProperty]
        public string Werkzaam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Manager = await _context.Manager.FirstOrDefaultAsync(m => m.ID == id);


            if (Manager == null)
            {
                return NotFound();
            }
            return Page();
        }

       
    }
}