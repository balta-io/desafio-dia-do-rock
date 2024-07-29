using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Models;
using DesafioDiaDoRock.ApplicationCore.Models.Integrations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioDiaDoRock.ApplicationCore.Services
{
    public class TokenService
    {
        public static string GenerateToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration.SECRET);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, usuario.Email),
                    new("id", usuario.Id.ToString()),
                    new(ClaimTypes.Role, usuario.Roles)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public static int GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token?.Split(" ").Last()) as JwtSecurityToken;

            if (jwtToken == null || !jwtToken.Claims.Any(c => c.Type == "id"))
            {
                throw new ArgumentException("Token inválido ou sem ID do usuário.");
            }

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new ArgumentException("ID do usuário ausente ou inválido no token.");
            }

            return userId;
        }
    }
}

