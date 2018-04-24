using CrowdSourcing.EntityCore.Context;
using CrowdSourcing.EntityCore.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrowdSourcing.Application.Web.Authorization
{
    public class MyAuthorizationServerProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new UserStore<PersonEntity>(new CrowdSourcingContext());
            var manager = new UserManager<PersonEntity>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var userRoles = await manager.GetRolesAsync(user.Id);              
                var mainRole = SetMainRole( userRoles);
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Id", user.Id));
                identity.AddClaim(new Claim("UserName",user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));
                identity.AddClaim(new Claim("MainRole", mainRole));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
               
                foreach (string roleName in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }
                var additionalData = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "role",Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                    }
                });
                var token = new AuthenticationTicket(identity, additionalData);
                context.Validated(identity);
            }
            else
                return;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        private string SetMainRole(IList<string> roles)
        {
            if (roles.Contains("admin"))
            {
                return "admin";
            }
            else if (roles.Contains("expert"))
            {
                return "expert";
            }
            else
            {
                return "user";
            }
        }
    }
}