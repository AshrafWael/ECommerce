using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ECommerce.BLL.Authentication
{
    public class BasicAuthenticationHandeler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandeler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

     
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
             if(!Request.Headers.ContainsKey("Authentication"))
                return Task.FromResult(AuthenticateResult.NoResult());
            try
            {
                // Read the Authorization header value
                //var authHeader = Request.Headers["Authorization"].ToString();
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                if (authHeader.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
                {
                    var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');
                    var username = credentials[0];
                    var password = credentials[1];
                    if (username == "testuser" && password == "password")
                    {
                        // Create authenticated user claims
                        var claims = new[]
                        { 
                                   new Claim(ClaimTypes.Name, username) ,
                                   new Claim (ClaimTypes.NameIdentifier,username)
                        };
                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        //identity or mor than identity
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);

                        return Task.FromResult(AuthenticateResult.Success(ticket));
                    }

                }
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));

            }
            catch (Exception ex) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));

            }


            }
    }
}

