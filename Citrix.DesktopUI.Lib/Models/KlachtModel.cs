using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.DesktopUI.Lib.Models
{
    public class KlachtModel
    {
        public DateTime DateAdded { get; set; }
        public bool Behandeld { get; set; } = false;


        // front end 

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int PhoneNumber { get; set; }

        public string Streetname { get; set; }

        public int HuisNummer { get; set; }

        public string PostCode { get; set; }

        public string KlachtDescription { get; set; }
        public string Toegezegd { get; set; }

        public DateTime DateKlacht { get; set; }
    }
}
