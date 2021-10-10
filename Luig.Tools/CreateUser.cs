using Luig.Commons;
using Luig.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Tools
{
    public static class CreateUser
    {
        public static void Create(string userName, string password, UserRoles role)
        {
            using (var db = new LuigDevEntities())
            {
                var user = new User()
                {
                    UserName = userName,
                    UserPassword = password,
                    UserRole = (int)role
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
