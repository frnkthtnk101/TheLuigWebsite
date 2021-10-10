using Luig.Dapper.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Luig.DAL
{
    public class SQLPlaygroundDAL
    {

        public List<PlayGroundModel> GetData(string sql)
        {
            using(var access = new SqlConnection())
            {
                var results = access.Query<PlayGroundModel>(sql).ToList();
                return results;
            }
        }
    }
}
