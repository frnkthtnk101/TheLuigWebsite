using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luig.DataModels;
using Teaching.Tools;

namespace Teaching.Business
{
    public class Authorizer
    { 

        public Authorizer()
        {
        }

        public bool Authorize(string userName, string password)
        {
            using(var db = new LuigDevEntities())
            {
                var protectedUserName = Security.Encrypt(userName);
                var protectedPassword = Security.Encrypt(password);
                var user = db.Users.Where(x => x.UserName == protectedUserName && x.UserPassword == protectedPassword).FirstOrDefault();
                return user != default(User);
            }

        }
    }
}