using Authentication_Authorization.Helpers;
using Authentication_Authorization.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Authorization.Services
{
    public interface IAuthenticateService
    {
        string AuthenticateUser(User user);

    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IOptions<JwtSettings> _option;

        //private object _appSettings;
        public AuthenticateService(IOptions<JwtSettings> option)
        {
            _option = option;
        }
        public string AuthenticateUser(User user)
        {


            return generateJwtToken(user, _option.Value.SecretsKey); ;
        }

        private string generateJwtToken(User user, string secretKey)
        {
            // generate token that is valid for 7 days

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
