using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Citrix.Data;
using Citrix.Models.Models.Klachten;

namespace Citrix
{
    public class CreateKlachtenModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public CreateKlachtenModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KlachtModel Klacht { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Klacht.Add(Klacht);
            await _context.SaveChangesAsync();
            Klacht = new KlachtModel();
            return RedirectToPage("./Index");
        }
    }
}
