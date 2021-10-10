using Luig.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Utility
{
    public class AuthorizationDAL
    {
        public string GetUsername(string userName, string password)
        {
            using (var db = new LuigDevEntities())
            {
       
                var user = db.Users.Where(x => x.UserName == userName && x.UserPassword == password).FirstOrDefault();
                string protectedUserName = string.Empty;
                if (user != default(User))
                    protectedUserName = user.UserName;
                return protectedUserName;
            }
        }
    }
}
