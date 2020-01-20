using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.DesktopUI.Models
{
    public class ManagerDisplayModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoPath { get; set; }

        public bool IsZiek { get; set; }

        public string Email { get; set; }

        public int RestaurantModelId { get; set; }

        public string FullName 
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
                
        }
    }
}
