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
    public class IndexKlachtenModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public IndexKlachtenModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<KlachtModel> KlachtModels { get; set; }
        [BindProperty]
        public KlachtModel Klacht { get; set; }

        public bool ShowEverything = false;
        public bool HideEverything = false;

        public async Task OnGetAsync()
        {
            KlachtModels = await _context.Klacht
                .Where(x => x.Behandeld == false)
                .Where(x => x.DateKlacht.Year == DateTime.UtcNow.Year)
                .ToListAsync();
        }

        public async Task OnPostShowEverythingAsync()
        {
            KlachtModels = await _context.Klacht
                .Where(x => x.DateKlacht.Year == DateTime.UtcNow.Year)
                .ToListAsync();
            ShowEverything = true;
        }
        public async Task OnPostHideEverythingAsync()
        {

            KlachtModels = await _context.Klacht
                .Where(x => x.Behandeld == false)
                .Where(x => x.DateKlacht.Year == DateTime.UtcNow.Year)
                .ToListAsync();
            HideEverything = true;
        }

        public async Task<IActionResult> OnPostSubmitKlachtAsync()
        {
            
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }
            Klacht.DateAdded = DateTime.Now;
            Klacht.Behandeld = false;


            _context.Klacht.Add(Klacht);
            await _context.SaveChangesAsync();
            Klacht = new KlachtModel();

            return RedirectToPage("./Index");

        }

        

    }
}
