using Core.Entities.Concrete;
using Core.Utilities.Token.Helpers;
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
            TokenOptions=Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken GenerateToken(User user)
        {
            var symetricSecurityKey=SecurityKeyHelper.GetSecurityKey(TokenOptions.SecurityKey);
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken
            (
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                expires: DateTime.UtcNow.AddDays(TokenOptions.ExpirationTime),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials

            );
            var token=new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AccessToken
            {
                Token = token
            };
        }

        //public Claim[] GetClaims(User user, List<RoleClaim> roleClaims)
        //{
        //    var claims = new List<Claim>();
        //    foreach (var property in properties)
        //    {
        //        claims.Add(new Claim());
        //    }
        //}
    }
}
