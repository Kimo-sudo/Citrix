using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.DesktopUI.Lib.Models
{
    public class Dagmail
    {
        // Kop
        public string DagDoelstelling { get; set; }

        public string ResultaatDagDoelStelling { get; set; }

        public string Sectie11 { get; set; }

        // Los

        public string Omzet { get; set; }

        public string Voorraadbeheer { get; set; }

        public string Personeel { get; set; }

        public string Apperatuur { get; set; }

        public string Overig { get; set; }


        public DateTime DateAdded { get; set; }
        public Restaurants Restaurant { get; set; }
    }
}
