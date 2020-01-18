using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;

namespace Citrix
{
    public class DeleteModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public DeleteModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manager Manager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manager = await _context.Manager.FirstOrDefaultAsync(m => m.Id == id);

            if (Manager == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manager = await _context.Manager.FindAsync(id);

            if (Manager != null)
            {
                _context.Manager.Remove(Manager);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}