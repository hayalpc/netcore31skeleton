using Microsoft.IdentityModel.Tokens;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Utils;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore31Skeleton.WebApi.Business.Concrete
{
    public class TokenCreator : ITokenCreator
    {
        public string CreateToken(AppUser appUser,List<AppRole> appUserRoles)
        {
            var token = CreateSecurityToken(appUser, appUserRoles);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken CreateSecurityToken(AppUser appUser, List<AppRole> appUserRoles)
        {
            var token = new JwtSecurityToken(
               issuer: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
               audience: Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: CreateCredentials(),
               claims: CreateClaims(appUser, appUserRoles)
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

        private List<Claim> CreateClaims(AppUser appUser, List<AppRole> appUserRoles)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Sid, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, appUser.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.FullName));
            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            if (appUserRoles != null && appUserRoles.Count > 0)
            {
                foreach (var userRole in appUserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Name.ToString()));
                }
            }
            return claims;
        }
    }
}
