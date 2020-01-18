using Citrix.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Citrix.Models.Models.Klachten
{
    public enum TypeKlacht
    {
        Voedselveiligheid, 
        MissendDrive,
        MissendCounter,
        Temperatuur, 
        Overig

    }
    public class KlachtModel : HoofdObject
    {
        // back end
        public DateTime DateAdded { get; set; }
        public bool Behandeld { get; set; } = false;


        // front end 

        [Required(ErrorMessage = "Je moet een voornaam invullen")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Je moet een achternaam invullen")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Je moet een telefoonnummer invullen")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Je moet een straatnaam invullen")]
        [MaxLength(128)]
        public string Streetname { get; set; }

        [Required(ErrorMessage = "Je moet een huisnummer invullen!")]
        public int HuisNummer { get; set; }

        [Required(ErrorMessage = "Je moet een postcode invullen!")]
        [MaxLength(7)]
        public string PostCode { get; set; }


        [Required(ErrorMessage = "Wat misde de klant")]
        [MaxLength(50)]
        public string KlachtDescription { get; set; }

        [Required(ErrorMessage = "Wat heb je toegezegd? (verplicht)")]
        [MaxLength(50)]
        public string Toegezegd { get; set; }
        [EnumDataType(typeof(TypeKlacht))]
        public TypeKlacht SoortKlacht { get; set; }


        [ValidationRangeMonth]
        public DateTime DateKlacht { get; set; }

    }
}
