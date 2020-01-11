using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;
using Citrix.Models.Models.Restaurant;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Citrix
{
    public class IndexModel : PageModel
    {
        private readonly Citrix.Data.ApplicationDbContext _context;

        public IndexModel(Citrix.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Manager> Manager { get; set; }
        [BindProperty]
        public IList<RestaurantModel> RestaurantModels { get; set; }
        [BindProperty]
        public List<SelectListItem> RestaurantSelection { get; set; }

        public bool IsChecked { get; set; }

        public async Task OnGetAsync()
        {
            RestaurantModels = await _context.Restaurant.ToListAsync();
            Manager = await _context.Manager.ToListAsync();

        }


        public void OnPost()
        {
            RestaurantSelection.Count();
        }

    }
}