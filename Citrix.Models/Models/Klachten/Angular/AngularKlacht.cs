using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models.Models.Klachten.Angular
{
    public class AngularKlacht
    {
        public enum TypeKlacht
        {
            Voedselveiligheid,
            MissendDrive,
            MissendCounter,
            Temperatuur,
            Overig

        }

        public int Id { get; set; }
        // back end
        public DateTime DateAdded { get; set; }
        public bool Behandeld { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Streetname { get; set; }
        public int HuisNummer { get; set; }
        public string PostCode { get; set; }
        public string KlachtDescription { get; set; }
        public string Toegezegd { get; set; }
        public TypeKlacht SoortKlacht { get; set; }
        public DateTime DateKlacht { get; set; }

        }
}
