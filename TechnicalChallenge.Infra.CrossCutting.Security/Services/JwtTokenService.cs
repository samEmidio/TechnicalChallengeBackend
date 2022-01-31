using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Infra.CrossCutting.Security.Interfaces;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;



namespace TechnicalChallenge.Infra.CrossCutting.Security.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private AppSettingsJwtToken _appSettingsJwtToken = new AppSettingsJwtToken();

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            _configuration.GetSection("AppSettingsJwtToken").Bind(_appSettingsJwtToken);
            
        }

        public string GenerateToken(Guid id, string name, string lastName, string email, string pass = null)
        {
            List<Claim> claimList = new List<Claim>();
            claimList.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            claimList.Add(new Claim(ClaimTypes.Name, name));
            claimList.Add(new Claim(ClaimTypes.Email, email));
            
            if (pass != null)
            {
                claimList.Add(new Claim("pass", pass));
            }

            var subjectRole = new ClaimsIdentity(claimList.ToArray());

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettingsJwtToken.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subjectRole,
                Issuer = _appSettingsJwtToken.Issuer,
                Audience = _appSettingsJwtToken.Audience,
                Expires = DateTime.UtcNow.AddHours(_appSettingsJwtToken.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

   
    }
}
