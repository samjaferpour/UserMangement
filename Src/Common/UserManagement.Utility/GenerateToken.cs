using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Utility
{
    public class GenerateToken
    {
        public static TokenDto GetToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Top Secret Key 112358"));
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "SampleJwtServer",
                Audience = "SampleJwtClient",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(2),
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredential,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(createdToken);
            var refreshToken = GetRefreshToken();
            var token = new TokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
            return token;
        }
        private static string GetRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public static void GetAccessTokenFromRefreshToken(string refreshToken)
        {

        }
    }
}
