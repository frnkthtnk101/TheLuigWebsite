using Luig.Dapper.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Luig.DAL
{
    public class SQLPlaygroundDAL
    {
        string ConnectionString { 
            get {

                return ConfigurationManager.ConnectionStrings["Luig.DataModels.Properties.Settings.LuigDevConnectionString"].ConnectionString;
            }
        }
        public List<object> GetData(string sql)
        {
            using(var access = new SqlConnection(ConnectionString))
            {
                var results = new List<object>();
                try
                {
                    results = access.Query<object>(sql).ToList();
                }
                catch(Exception e)
                {
                    results.Add(new Dictionary<string, string>() { { "error", e.Message } });
                }
                return results;
            }
        }
    }
}
