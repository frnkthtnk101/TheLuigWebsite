using Luig.Tools.ConvertPlayUsersToDBSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luig.Tools
{
    public interface MyScreen : IDisposable
    {
        void Go();
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var screen = new CreateUsers())
                screen.Go();
        }
    }
}
