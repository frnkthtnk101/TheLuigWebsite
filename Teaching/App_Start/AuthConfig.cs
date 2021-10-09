using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Teaching.Business;

namespace Teaching.App_Start
{
    public class AuthConfig
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var oauthProvider = new OAuthAuthorizationServerProvider
            {
                OnGrantResourceOwnerCredentials = async context =>
                {
                    var authorizer = new Authorizer();
                    var authorizedUser = authorizer.Authorize(context.UserName, context.Password);
                    if (authorizedUser)
                    {
                        var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                        claimsIdentity.AddClaim(new Claim("user", context.UserName));
                        context.Validated(claimsIdentity);
                        return;
                    }
                    context.Rejected();
                },
                OnValidateClientAuthentication = async context =>
                {
                    string clientId;
                    string clientSecret;
                    if (context.TryGetBasicCredentials(out clientId, out clientSecret))
                    {
                        //for testing purposes, I want to keep this for now.
                        if (clientId == "CMIS308DS308" && clientSecret == "ThisIsNoSecretKey")
                        {
                            context.Validated();
                        }
                    }
                }
            };
            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/accesstoken"),
                Provider = oauthProvider,
                AuthorizationCodeExpireTimeSpan = TimeSpan.FromMinutes(1),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
                SystemClock = new SystemClock()

            };
            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}