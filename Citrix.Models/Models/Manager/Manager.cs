using Citrix.Models.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citrix.Models
{
    public class Manager : IManager
    {
        [Required]
        public int ID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [MaxLength(250)]
        [Display(Name = "Foto bestand")]
        public string PhotoPath { get; set; }

        [DefaultValue("false")]
        public bool IsZiek { get; set; }

        public int RestaurantModelId { get; set; }


    }
}