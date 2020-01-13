using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models.Models.Klachten;

namespace Citrix
{
    public class EditKlachtenModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditKlachtenModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KlachtModel KlachtModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KlachtModel = await _context.Klacht.FirstOrDefaultAsync(m => m.Id == id);

            if (KlachtModel == null)
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

            _context.Attach(KlachtModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlachtModelExists(KlachtModel.Id))
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

        private bool KlachtModelExists(int id)
        {
            return _context.Klacht.Any(e => e.Id == id);
        }
    }
}
