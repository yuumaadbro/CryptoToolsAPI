using Azure.Core;
using CryptoToolsAPI.DbContext;
using CryptoToolsAPI.DTOs.Authorization;
using CryptoToolsAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoToolsAPI.DataMappers
{
    public class AuthorizationDataMapper
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public AuthorizationDataMapper(Context context, IConfiguration configuration) 
        { 
            _context = context;
            _configuration = configuration;
        }

        public Users IsUserAuthorized(AuthorizationRequestDTO credentials) 
        {
            if (credentials == null) return new Users(); 
                
            var user = _context.Users.Where(x => x.Email.Equals(credentials.Email) && x.Enabled)
                    .FirstOrDefault();
            if(user == null) return new Users();

            if (BCrypt.Net.BCrypt.Verify(credentials.Password, user.Password)) return user;

            return new Users();
        }

        public AuthorizationResponseDTO GetAuthorizationResponse(Users user) 
        { 
            return GetUserToken(user);
        }

        public AuthorizationResponseDTO GetUserToken(Users user) 
        {
            var TokenLifeTime = TimeSpan.FromMinutes(1440);
            var TokenSecret = _configuration["JwtSettings:Key"]!;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("userid", user.ID.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthorizationResponseDTO 
            { 
                Token = tokenHandler.WriteToken(token),
                Expiration = DateTime.Now.AddMinutes(1440),
                Claims = user.Claim
            };
        }

        public List<Claim> GetUserClaims(string userID) 
        { 
            var claims = new List<Claim>();
            if (userID.IsNullOrEmpty()) return claims;

            var user = _context.Users.Where(x => x.ID.ToString().Equals(userID.ToUpper())).FirstOrDefault();
            if(user == null) return claims;

            string[] claimNames = user.Claim.Split(";");
            string[] claimValues = user.Value.Split(";");

            if (claimNames.Length == claimValues.Length) 
            { 
                for( int i = 0; i < claimNames.Length; i++) 
                { 
                    var claim = new Claim(claimNames[i], claimValues[i]);
                    claims.Add(claim);
                }

                return claims;
            }

            return claims;
        }
    }
}
