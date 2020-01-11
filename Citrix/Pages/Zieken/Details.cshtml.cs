using Citrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Citrix
{
    public class ZiekDetailsModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public ZiekDetailsModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ZiekModel ZiekModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ZiekModel = await _context.ZiekModel.FirstOrDefaultAsync(m => m.ID == id);

            if (ZiekModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}