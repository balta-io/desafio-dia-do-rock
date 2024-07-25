using DesafioDiaDoRock.ApplicationCore.Extension;
using DesafioDiaDoRock.ApplicationCore.Services;
using DesafioDiaDoRock.UI.JS;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DesafioDiaDoRock.UI.Services
{
    public class AuthenticationService : DelegatingHandler
    {
        private readonly IJSRuntime jSRuntime;
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public AuthenticationService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            JsInterop jsInterop = new JsInterop(jSRuntime);

            var token = await jsInterop.GetToken();

            request.Headers.Add("Authorization", token);

            return await base.SendAsync(request, cancellationToken);
        }


        public async void UpdateAuthenticationState(string jwtToken)
        {
            var claimsPrincipal = new ClaimsPrincipal();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                JsInterop jsInterop = new JsInterop(jSRuntime);
                await jsInterop.SetToken(jwtToken);

                var getUserClaims = DecryptToken(jwtToken);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                JsInterop jsInterop = new JsInterop(jSRuntime);
                await jsInterop.SetToken("");
            }
        }

        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Email == null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new (ClaimTypes.Name, claims.Email!)
                }, "JwtAuth"));
        }

        private static CustomUserClaims DecryptToken(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken)) return new CustomUserClaims();

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var email = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            return new CustomUserClaims(email);
        }
    }
}

