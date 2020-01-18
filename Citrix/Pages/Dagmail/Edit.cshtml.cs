using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Citrix
{
    // [Authorize(Roles = "Admin")]
    public class EditDagmailModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public EditDagmailModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dagdeel Dagdeels { get; set; }

        public async Task<IActionResult> OnGetAsync(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Dagdeels = await _context.Dagdeel.FirstOrDefaultAsync(m => m.Id == ID);

            if (Dagdeels == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dagdeels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DagdeelExisits(Dagdeels.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = Dagdeels.Id }) ;
        }

        private bool DagdeelExisits(int id)
        {
            return _context.Dagdeel.Any(e => e.Id == id);
        }
    }
}