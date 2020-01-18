using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.DesktopUI.Lib.Models
{
    public class Restaurants
    {


        public string RestaurantName { get; set; }

        public List<Manager> ManagersWerkzaam { get; set; }

        public string Adress { get; set; }
        public string TelefoonNummer { get; set; }

        public string Email { get; set; }
    }
}
