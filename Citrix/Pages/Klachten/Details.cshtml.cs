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
    public class DetailsKlachtenModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsKlachtenModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
