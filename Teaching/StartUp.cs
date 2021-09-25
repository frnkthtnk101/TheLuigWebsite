using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Teaching.App_Start;

[assembly: OwinStartup(typeof(Teaching.Startup))]

namespace Teaching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authentication = new AuthConfig();
            authentication.ConfigureAuth(app);
        }
    }
}
