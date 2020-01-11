using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;

namespace Citrix
{
    public class EditModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public EditModel(Citrix.Data.ApplicationDbContext context)
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

            Manager = await _context.Manager.FirstOrDefaultAsync(m => m.ID == id);

            if (Manager == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(Manager.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.ID == id);
        }
    }
}