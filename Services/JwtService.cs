using MaxonEventManagement.Models;
using MaxonEventManagement.Services.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MaxonEventManagement.Services
{
    public class JwtService : IJwt
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public string GenerateToken(User user)
        {
            //read from appsettings
            var secretKey = _configuration.GetSection("JwtOptions:SecretKey").Value;
            var audience = _configuration.GetSection("JwtOptions:Audience").Value;
            var issuer = _configuration.GetSection("JwtOptions:Issuer").Value;
            //key-secret key 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //cred security algorithm to be used in encryption
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //what will be contained in the payload 
            //Avoid passing fields like password or email to the payload to avoid exposing them

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Roles", user.Roles));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));

            //Bringing all these together to create a token
            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddHours(3),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = cred
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokendescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
