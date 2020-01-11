using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models.Models
{

    public enum DagmailOmzet
    {
        Omzet,
        Hoog,
        Laag

    }


    public class Dagmail
    {
        public string ResultaatDagDoelStelling { get; set; }
        public DateTime DateAdded { get; set; }

        public DagmailOmzet Type { get; set; }
    }
}
