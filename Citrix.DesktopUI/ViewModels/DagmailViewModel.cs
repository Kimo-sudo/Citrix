using Caliburn.Micro;
using Citrix.Data;
using Citrix.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.DesktopUI.ViewModels
{
    public class DagmailViewModel : Screen
    {

        private readonly ApplicationDbContext _context;

        public DagmailViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dagdeel> Dagdeels { get; set; }



        public class GetDagmail
        {
           
        }
    }
}
