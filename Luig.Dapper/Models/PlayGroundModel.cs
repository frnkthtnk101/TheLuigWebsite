using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Dapper.Models
{
    public class PlayGroundModel
    {
        public int gender_id { get; set; }
        public string gender_name { get; set; }
        public string gender_description { get; set; }
        public int house_address_id { get; set; }
        public string house_address_line_one { get; set; }
        public string house_address_line_two { get; set; }
        public int house_address_zip_id { get; set; }
        public int living_situation_person_id { get; set; }
        public int living_situation_house_address_id { get; set; }
        public int person_id { get; set; }
        public string person_first_name { get; set; }
        public string person_last_name { get; set; }
        public string person_email_name { get; set; }
        public int person_gender_id { get; set; }

    }
}
