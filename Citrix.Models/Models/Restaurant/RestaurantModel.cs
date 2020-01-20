using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models.Models.Restaurant
{
    public class RestaurantModel : HoofdObject
    {
        public List<Manager> ManagersWerkzaam { get; set; }

        public string Adress { get; set; }
        public string TelefoonNummer { get; set; }

        public string Email { get; set; }


    }
}
