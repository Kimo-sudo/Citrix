using System;
using System.Collections.Generic;
using System.Text;

namespace Citrix.Models.Services.DataAccess
{
    public class SqlDataAcces
    {
        private string _connectionString;

        public SqlDataAcces(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
