using Citrix.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Citrix.Models.Services
{
    public interface IDagmailService
    {
        Task<Dagmail> GetDagmail(DagmailOmzet dagmailOmzet);




    }
}
