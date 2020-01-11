using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Citrix
{
    [Authorize(Roles = "Admin")]
    public class DagmailDetailsModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public DagmailDetailsModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dagdeel Dagdeels { get; set; }

        public async Task<IActionResult> OnGetAsync(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            Dagdeels = await _context.Dagdeel.FirstOrDefaultAsync(m => m.ID == ID);

            if (Dagdeels == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}