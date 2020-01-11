using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Data;
using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Citrix
{
    [Authorize(Roles = "Admin")]
    public class IndexDagmailModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public IndexDagmailModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dagdeel> Dagdeels { get; set; }
        public IList<ZiekModel> ZiekModels { get; set; }

        public async Task OnGetAsync()
        {
            ZiekModels = await _context.ZiekModel.ToListAsync();
            Dagdeels = await _context.Dagdeel.ToListAsync();
        }
    }
}