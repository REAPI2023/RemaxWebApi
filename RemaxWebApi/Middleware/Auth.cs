using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using RemaxWebApi.Interfaces;
using RemaxWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RemaxWebApi.Middleware
{
    public class Auth : IJwtAuth
    {
        public readonly RelEstDbContext _context;
        public readonly string _key;

        public Auth(RelEstDbContext context,IConfiguration config)
        {
            _context = context;
            _key = config.GetValue<string>("AuthKey");
                
        }
        public string Authentication(string emailId)
        {
            if (!_context.Users.Any(x => x.Email.Equals(emailId)))
                return null;

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, emailId)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);

        }
    }
}
