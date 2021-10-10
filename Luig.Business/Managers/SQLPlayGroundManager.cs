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

        public List<SqlPlayGroundRow> GetPlayGroundResponse(string sql)
        {
            var access = new SQLPlaygroundDAL();
            var results = new List<SqlPlayGroundRow>();
            var executedResults = access.GetData(sql).Take(15);
            foreach(var item in executedResults)
            {
                results.Add(new SqlPlayGroundRow() { 
                    person_first_name = item.person_first_name,
                    gender_description = item.gender_description,
                    gender_id = item.gender_id,
                    gender_name = item.gender_name,
                    house_address_id = item.house_address_id,
                    house_address_line_one = item.house_address_line_one,
                    house_address_line_two = item.house_address_line_two,
                    person_gender_id = item.person_gender_id,
                    house_address_zip_id = item.house_address_zip_id,
                    living_situation_house_address_id = item.living_situation_house_address_id,
                    living_situation_person_id = item.living_situation_person_id,
                    person_email_name = item.person_email_name,
                    person_id = item.person_id,
                    person_last_name = item.person_last_name
                });
            }
            return results;
        }
    }

    public class SqlPlayGroundRow : PlayGroundModel { }
}
