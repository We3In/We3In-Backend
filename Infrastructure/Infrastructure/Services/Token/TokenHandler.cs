using Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.Dtos.Token CreateAccessToken(int hours)
        {
            Application.Dtos.Token token = new();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:IssuesSigninKey"]));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            token.Expires = DateTime.Now.AddHours(hours);

            JwtSecurityToken secureToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expires,
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );

            //Token sınıfından örnek
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(secureToken);

            return token;

        }
    }
}
