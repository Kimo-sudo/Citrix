using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models.Models.Restaurant
{
    public class RestaurantModel
    {
        public int Id { get; set; }

        public string RestaurantName { get; set; }

        public List<Manager> ManagersWerkzaam { get; set; }

        public string Adress { get; set; }
        public string TelefoonNummer { get; set; }


    }
}
