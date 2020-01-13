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


    public class KlachtModel
    {
        // back end
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Behandeld { get; set; } = false;


        // front end 

        [Required(ErrorMessage = "Je moet een voornaam invullen")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Je moet een achternaam invullen")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Je moet een telefoonnummer invullen")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Je moet een straatnaam invullen")]
        public string Streetname { get; set; }
        [Required(ErrorMessage = "Je moet een huisnummer invullen!")]
        public int HuisNummer { get; set; }
        [Required(ErrorMessage = "Je moet een postcode invullen!")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Wat misde de klant")]
        public string KlachtDescription { get; set; }
        [Required(ErrorMessage = "Wat heb je toegezegd? (verplicht)")]
        public string Toegezegd { get; set; }

        public TypeKlacht SoortKlacht { get; set; }


        [ValidationRangeMonth]
        public DateTime DateKlacht { get; set; }

    }
}
