using Core.Entities.Concrete;
using Core.Utilities.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Identities.Jwt
{
    public class JwtService : ITokenService
    {
        private readonly IConfiguration Configuration;
        private readonly TokenOptions TokenOptions;
        public JwtService(IConfiguration configuration)
        {
            Configuration = configuration;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken GenerateToken(User user, List<RoleClaim> roleClaims)
        {
            var symetricSecurityKey = SecurityKeyHelper.GetSecurityKey(TokenOptions.SecurityKey);
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = GetClaims(user, roleClaims);


            var securityToken = new JwtSecurityToken
            (
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(TokenOptions.ExpirationTime),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AccessToken
            {
                Token = token
            };
        }

        public List<Claim> GetClaims(User user, List<RoleClaim> roleClaims)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
            };

            if (roleClaims.Count()>0)
            {
                foreach (var roleClaim in roleClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleClaim.Name.ToLower()));
                }
            }

            return claims;
        }
    }
}
