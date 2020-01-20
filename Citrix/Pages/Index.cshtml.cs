using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Data;
using Citrix.Models;
using Citrix.Models.Models.Klachten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Citrix.Pages
{
    // [Authorize(Roles = "Crewtrainer")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Citrix.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, Citrix.Data.ApplicationDbContext context)
        {
            _context = context;

            _logger = logger;
        }

        private DateTime d = DateTime.Now;

        [BindProperty]
        public IList<Models.Manager> Manager { get; set; }
        [BindProperty]
        public IList<KlachtModel> Klachten { get; set; }

        [BindProperty]
        public IList<ZiekModel> HuidigZieken { get; set; }

        [BindProperty]
        public Dagdeel Dagdeels { get; set; }

        public int NummerHuidigeZieken = 1;

        public async Task OnGetAsync()
        {
            Manager = await _context.Manager.ToListAsync();

            Dagdeels = await _context.Dagdeel.FirstOrDefaultAsync(m => m.DateAdded.Date == d.Date);

            HuidigZieken = await _context.ZiekModel.ToListAsync();

            Klachten = await _context.Klacht.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Dagdeels = await _context.Dagdeel.FirstOrDefaultAsync(m => m.DateAdded.Date == d.Date);
            if (Dagdeels == null)
            {
                Dagdeel dagdeel = new Dagdeel();
                dagdeel.DateAdded = DateTime.Now;
                _context.Dagdeel.Add(dagdeel);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/index");
        }
    }
}