using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Desafio.Infra.API.Security
{
    public static class OAuth
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public static void Configure(IAppBuilder app)
        {
            var authAuthorizationServerOptions = new OAuthAuthorizationServerOptions
            {
                /*
                 * AllowInsecureHttp deve ser false para produção
                 */
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://jwtauthzsrv.azurewebsites.net"),
            };

            app.UseOAuthAuthorizationServer(authAuthorizationServerOptions);

            const string ISSUER = "http://jwtauthzsrv.azurewebsites.net";
            const string AUDIENCE = "099153c2625149bc8ecb3e85e03f0022";
            byte[] secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            var authenticationOptions = new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { AUDIENCE },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(ISSUER, secret)
                }
            };

            app.UseJwtBearerAuthentication(authenticationOptions);
        }
    }
}