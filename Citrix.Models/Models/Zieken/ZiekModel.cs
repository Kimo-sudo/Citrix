using Citrix.Models.Models;
using Citrix.Models.Models.Restaurant;
using Citrix.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Citrix.Models
{
    public class ZiekModel : HoofdObject
    {
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vereist...")]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "Vermoedelijke duur (dagen)")]
        public string Duur { get; set; }

        [Display(Name = "Telefoon nummer")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Beter melden")]
        public bool BeterGemeld { get; set; }

        [ValidationRangeMonth]
        public DateTime DagZiek { get; set; }

    }
}