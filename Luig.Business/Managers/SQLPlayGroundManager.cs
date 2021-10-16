using Luig.DAL;
using Luig.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Business.Managers
{
    public class SQLPlayGroundManager
    {
        public SQLPlayGroundManager()
        {

        }

        public List<object> GetPlayGroundResponse(string sql)
        {
            var access = new SQLPlaygroundDAL();
            var results = new List<object>();
            var executedResults = access.GetData(sql).Take(15);
            results.AddRange(executedResults);
            return results;
        }
    }

    public class SqlPlayGroundRow : PlayGroundModel { }
}
