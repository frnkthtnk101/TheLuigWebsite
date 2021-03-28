using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Luig.Data.Models;
using System.Linq;

namespace Luig.Data
{
    public static class DataLuigContext
    {
        static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DataLuig"].ConnectionString;
            }

        }

        public static WIP[] GetLatestWips()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<WIP>("SELECT * FROM WorkInProgress").ToArray();
            }
        }
    }
}
