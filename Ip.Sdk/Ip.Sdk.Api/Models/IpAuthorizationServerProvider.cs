using Ip.Sdk.Api.Enumerations;
using Ip.Sdk.Security.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ip.Sdk.Api.Models
{
    /// <summary>
    /// Overriden Service Provider for Auth
    /// </summary>
    public class IpAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Overrides the base method to validate the client
        /// </summary>
        /// <param name="context">The auth context</param>
        /// <returns>If the client is valid</returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.TryGetFormCredentials(out string clientId, out string clientSecret);

            var clientValid = await ValidateClientAsnyc(clientId, clientSecret);

            if (clientValid)
            {
                context.Validated(clientId);
            }
        }

        /// <summary>
        /// Overrides the base method to authenticate the client
        /// </summary>
        /// <param name="context">The auth context</param>
        /// <returns>If the client is authenticated and their claims</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IIpUser user = new IpUser();

            var result = await user.AuthenticateAsync(context.UserName, context.Password);

            if (result.Status != (int)AuthenticationStatus.Success)
            {
                context.SetError("invalid_grant", "The username or password is incorrect");
                return;
            }

            user = await user.GetByUsernameAsync(context.UserName);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            foreach (var c in user.Claims)
            {
                identity.AddClaim(new Claim(c.ClaimKey, c.ClaimValue));
            }

            context.Validated(identity);
        }

        private async Task<bool> ValidateClientAsnyc(string clientId, string clientSecret)
        {
            return await Task.Run(() => ValidateClient(clientId, clientSecret));
        }

        private bool ValidateClient(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
            {
                return false;
            }

            //TODO: Call to whatever our store is for auth and see if the client and the client secret exist and are matched
            return true;
        }
    }
}