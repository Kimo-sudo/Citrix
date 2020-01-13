using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Citrix.Models.Models.Klachten
{
    public class KlachtModel
    {

        public int Id { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int PhoneNumber { get; set; }

        public string Streetname { get; set; }

        public int HuisNummer { get; set; }

        public string PostCode { get; set; }
        public string KlachtDescription { get; set; }

        public string Toegezegd { get; set; }

        public bool Behandeld { get; set; } = false;


        public DateTime DateAdded { get; set; }

        public DateTime DateKlacht { get; set; }

    }
}
