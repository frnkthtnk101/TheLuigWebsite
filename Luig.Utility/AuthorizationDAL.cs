using Luig.DataModels;
using System;
using System.Linq;

namespace Luig.DAL
{
    public class AuthorizationDAL
    {
        public bool Authorize(int userName, int password)
        {
            using (var db = new LuigConnectionString())
            {
                try
                {
                    var users = db.Users.Where(x => x.UserName == userName && x.UserPassword == password).FirstOrDefault();
                    return users != null;
                }
                catch(Exception e)
                {
                    return false;
                }

            }
        }
    }
}
