using Citrix.Models.Models.Klachten;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Citrix.Models.Services.KlachtenData
{
    public class KlachtenDataService
    {
        private string _con;

        public KlachtenDataService(string connectionString)
        {
            _con = connectionString;
        }

        public IEnumerable<KlachtModel> GetAll()
        {
            using (var connection = new SqlConnection(_con))
            {
                string sql = "select * from Klacht";
                return connection.Query<KlachtModel>(sql);
            }
        }

    }
}