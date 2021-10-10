using Luig.Helpers;
using Luig.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Business.Managers
{
    public class AuthorizationManager : IDisposable
    {
        AuthorizationDAL DataAccess;

        public AuthorizationManager()
        {
            DataAccess = new AuthorizationDAL();
        }

        public bool AuthorizeCredentials(string userName, string password)
        {
            var protectedUserName = DataAccess.GetUsername(userName, password);
            return !string.IsNullOrEmpty(protectedUserName);
        }

        public void Dispose()
        {
        }

        public string ProtectString(string stringToEncrypt)
        {
            return Security.Encrypt(stringToEncrypt);
        }
    }
}
