using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models.Models.Klachten;

namespace Citrix
{
    public class DeleteKlachtenModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public DeleteKlachtenModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KlachtModel = await _context.Klacht.FindAsync(id);

            if (KlachtModel != null)
            {
                _context.Klacht.Remove(KlachtModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
