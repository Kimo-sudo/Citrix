using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Citrix.Data;
using Citrix.Models;

namespace Citrix
{
    public class CreateModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public CreateModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manager Manager { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Manager.Add(Manager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}