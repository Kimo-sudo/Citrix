using Citrix.Models.Models;
using Citrix.Models.Models.Restaurant;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Citrix.Models
{
    public class Dagdeel : HoofdObject
    {

        // Kop
        [Display(Name = "Doelstelling van de Dag")]
        public string DagDoelstelling { get; set; }
        [Display(Name = "Resultaat doelstelling van de Dag")]
        public string ResultaatDagDoelStelling { get; set; }
        [Display(Name = "Sectie 11")]
        public string Sectie11 { get; set; }

        // Los
        [MaxLength(280)]
        public string Omzet { get; set; }
        [MaxLength(280)]
        public string Voorraadbeheer { get; set; }
        [MaxLength(280)]
        public string Personeel { get; set; }
        [MaxLength(280)]
        public string Apperatuur { get; set; }
        [MaxLength(280)]
        public string Overig { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }
        public RestaurantModel Restaurant { get; set; }

    }
}
