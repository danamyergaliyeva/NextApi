using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Abitech.NextApi.Server.Tests.Security.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Tasks.Server.Tests.Common.Auth
{
    public class TestAuthHandler : AuthenticationHandler<TestAuthOptions>
    {
        public TestAuthHandler(IOptionsMonitor<TestAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var headerAvailable = Request.Headers.Any(h => h.Key == "Authorization");
            if (!headerAvailable)
            {
                return AuthenticateResult.NoResult();
            }
            var sub = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]).Parameter;
            if (string.IsNullOrEmpty(sub))
            {
                return AuthenticateResult.NoResult();
            }

            return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(
                new ClaimsIdentity(new Claim[] {new Claim("sub", sub)}, "sub")
            ), "Tests"));
        }
    }
}
