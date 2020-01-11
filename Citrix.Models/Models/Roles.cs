using Citrix.Models.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models
{
    public class Roles
    {
        public string ID { get; set; }
        public string Functie { get; set; }
        public RestaurantModel Restaurant { get; set; }
    }
}