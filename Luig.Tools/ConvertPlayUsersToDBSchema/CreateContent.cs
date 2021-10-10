using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Tools.ConvertPlayUsersToDBSchema
{
    public class CreateContent : MyScreen
    {
        StringBuilder OutputFileContent;
        DataRows[] InputContent;
        //Dictionary<string, int> Genders, Zip, HomeAddress, Person;
        Dictionary<string, int> keyValues;
        public CreateContent()
        {
            OutputFileContent = new StringBuilder();
            keyValues = new Dictionary<string, int>();

        }
        public void Dispose()
        {

        }

        public void Go()
        {
            var filePath = @"C:\Users\Luig\Documents\GitHub\TheLuigWebsite\Luig.Tools\MOCK_DATA.xlsx";
            var outputPath = @"C:\Users\Luig\Documents\GitHub\TheLuigWebsite\Luig.Tools\MOCK_DATA.sql";
            var excelMapper = new ExcelMapper(filePath);
            InputContent = excelMapper.Fetch<DataRows>().ToArray();
            int i = 0;
            foreach (var row in InputContent)
            {
                row.first_name = row.first_name.Replace("'", "''");
                row.last_name = row.last_name.Replace("'", "''");
                if (!keyValues.ContainsKey(row.gender))
                {
                    keyValues.Add(row.gender, i);
                    OutputFileContent.AppendLine($"INSERT INTO GENDER(gender_id, gender_discription, gender_name) VALUES({i}, '{row.gender}', '{row.gender}')");

                }
                OutputFileContent.AppendLine($"INSERT INTO PERSON(person_id, person_gender_id, person_first_name, person_last_name, person_email_name) VALUES({i},{keyValues[row.gender]},'{row.first_name}','{row.last_name}','{row.email}')");
                if (!keyValues.ContainsKey(row.zip + row.city + row.state))
                {
                    keyValues.Add(row.zip + row.city + row.state, i);
                    OutputFileContent.AppendLine($"Insert into zip(zip_id, zip_code, zip_city, zip_state)Values ({i},'{row.zip}','{row.city}','{row.state}')");
                }
                if (!keyValues.ContainsKey(row.address))
                {
                    keyValues.Add(row.address, i);
                    var zipId = keyValues[row.zip + row.city + row.state];
                    OutputFileContent.AppendLine($"Insert into HOUSE_ADDRESS(house_address_id , house_address_line_one, house_address_line_two, house_address_zip_id) VALUES({i},'{row.address}','',{zipId}) ");
                }
                var addressId = keyValues[row.address];
                OutputFileContent.AppendLine($"INSERT INTO LIVING_SITUATION(living_situation_person_id,living_situation_house_address_id) VALUES({i},{addressId})");
                i++;
            }
            File.WriteAllText(outputPath, OutputFileContent.ToString());
        }
    }

    public class DataRows
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string address { get; set; }

    }
}
