using Microsoft.IdentityModel.Tokens;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore31Skeleton.WebApi.Core.Utils
{
    public class TokenCreator : ITokenCreator
    {

        public string CreateToken()
        {
            var token = CreateSecurityToken();

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken CreateSecurityToken()
        {
            var token = new JwtSecurityToken(
               issuer: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
               audience: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: CreateCredentials(),
               claims: CreateClaims()
             );
            return token;
        }

        public SigningCredentials CreateCredentials()
        {
            var secretKey = Helper.GetConfigStr("JwtSecurityKey", "JwtSecurityKey2020");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return creds;
        }

        private List<Claim> CreateClaims()
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.Role, "Member"));

            return claims;
        }
    }
}
