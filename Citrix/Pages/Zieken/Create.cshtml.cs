using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Citrix
{
    public class CreateZiekenModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public CreateZiekenModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Manager> Manager { get; set; }

        [BindProperty]
        public ZiekModel ZiekModel { get; set; }

        public async Task OnGetAsync()
        {
            Manager = await _context.Manager.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("/Zieken/Create");
        }
    }
}