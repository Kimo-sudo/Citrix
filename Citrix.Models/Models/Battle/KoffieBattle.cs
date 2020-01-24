using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Citrix.Models.Models.Battle
{
    public class KoffieBattle
    {
        public DateTime datum { get; set; }
        public int Groot { get; set; }
        public int Medium { get; set; }
        public string NameManager { get; set; }
        public string NameRestaurant { get; set; }


        public string Percentage
        {
            get
            {
                decimal totaal = Groot + Medium;
                decimal groot = Groot;
                decimal percentile = groot / totaal;
                string procent = percentile.ToString("P1", CultureInfo.InvariantCulture);
                return procent;
            }
        }
    }
}
