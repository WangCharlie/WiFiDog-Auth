using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Dapper;

namespace WiFiAuth.Web.Services
{
    public class WiFiAuthService : IWiFiAuthService
    {
        private readonly string _connectionString;

        public WiFiAuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void TestLite()
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                //var d = conn.Query("SELECT * FROM User;");
            }
        }
    }
}
