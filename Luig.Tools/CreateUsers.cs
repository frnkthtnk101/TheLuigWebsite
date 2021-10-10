using Luig.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Tools
{
    public class CreateUsers : MyScreen 
    {
        AuthorizationManager Authorizer;
        public CreateUsers()
        {
            Authorizer = new AuthorizationManager();
        }
        public void Dispose()
        {
            
        }

        public void Go()
        {
            Console.WriteLine("CreateUsers - Enter UserName and Password and this program will add it to the database");
            while (true)
            {
                var username = GetInput("userName : ");
                if (string.IsNullOrEmpty(username)) break;
                var password = GetInput("password : ");
                if (string.IsNullOrEmpty(password)) break;
                var protectedUserName = Authorizer.ProtectString(username);
                var protectedPassword = Authorizer.ProtectString(password);
                CreateUser.Create(protectedUserName, protectedPassword, Commons.UserRoles.Student);
            }
        }

        public string GetInput(string caption)
        {
            Console.WriteLine(caption);
            return Console.ReadLine();
        }
    }
}
