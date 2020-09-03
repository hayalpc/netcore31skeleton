using Microsoft.IdentityModel.Tokens;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NetCore31Skeleton.WebApi.Core.Utils
{
    public class TokenCreator : ITokenCreator
    {
        public string CreateToken()
        {

            var secretKey = Helper.GetConfigStr("JwtSecurityKey", "JwtSecurityKey2020");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                audience: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
