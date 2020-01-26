using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Models.Models.Klachten;
using Citrix.Models.Services.DataAccess;
using Citrix.Models.Services.KlachtenData;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Citrix.Controllers.KlachtControllers
{
    [Route("api/klachten")]
    [ApiController]
    public class KlachtController : ControllerBase
    {
        KlachtenDataService _con;
        public KlachtController(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            string connectionString = connection.Thuis;
            _con = new KlachtenDataService(connectionString);
        }

        [HttpGet]
        public IEnumerable<KlachtModel> GetAll()
        {
            return _con.GetAll();
        }


    }
}
