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
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly IJSRuntime jSRuntime;
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public AuthenticationService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                JsInterop jsInterop = new JsInterop(jSRuntime);

                var token = await jsInterop.GetToken();

                if (string.IsNullOrEmpty(token))
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var getUserClaims = DecryptToken(token);
                if (getUserClaims == null) return await Task.FromResult(new AuthenticationState(anonymous));

                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }

            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
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
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
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
            if(string.IsNullOrEmpty(jwtToken)) return new CustomUserClaims();

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var email = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            return new CustomUserClaims(email);
        }

        
    }
}

