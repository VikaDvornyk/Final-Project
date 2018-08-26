using FinalProjectDTO;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL
{
    public class ApplicationOAuthProviderBLL : OAuthAuthorizationServerProvider
    {
        ApplicationOAuthProviderDAL provider = new ApplicationOAuthProviderDAL();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await provider.ValidateClientAuthentication(context);
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var result = provider.GrantResourceOwnerCredentials(context);
        }
    }
}
