using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Data;
using Citrix.Models.Models.Klachten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Citrix
{
    public class KlachtenBriefModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public KlachtenBriefModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public KlachtModel Klacht { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Klacht = await _context.Klacht.FirstOrDefaultAsync(m => m.Id == id);

            if (Klacht == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}