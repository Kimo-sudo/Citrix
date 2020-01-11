using Citrix.Data;
using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citrix
{
    public class ZiekenIndexModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public ZiekenIndexModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<ZiekModel> Zieken { get; set; }

        public List<SelectListItem> Managers { get; set; }

        public DateTime Verschil { get; set; }

        [BindProperty]
        public ZiekModel ZiekToevoegen { get; set; }

        public int NummerHuidigeZieken = 1;

        public async Task OnGetAsync()
        {
            Zieken = await _context.ZiekModel.ToListAsync();

            Managers = _context.Manager.Select(a =>
                            new SelectListItem
                            {
                                Value = a.ID.ToString(),
                                Text = a.FirstName
                            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.ZiekModel.Add(ZiekToevoegen);
            await _context.SaveChangesAsync();
            ZiekToevoegen = new ZiekModel();
            return RedirectToPage("/zieken/index");
        }
    }
}