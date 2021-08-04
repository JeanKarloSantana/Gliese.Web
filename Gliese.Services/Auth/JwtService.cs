using Gliese.Entities;
using Gliese.Entities.Token;
using Gliese.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Services.Auth
{
    public class JwtService : IJwtService
    {
        private readonly Token _token;
        private readonly UserManager<User> _userManager;

        public JwtService(IOptions<Token> token, UserManager<User> userManager) 
        {
            _token = token.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = await GetValidClaims(user);

            var sysKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token.Secret));
            
            var signingCredentials = new SigningCredentials(sysKey, SecurityAlgorithms.HmacSha256);
            
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(_token.AccessExpiration),
                issuer: _token.Issuer,
                audience: _token.Issuer
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return await Task.FromResult(token);
        }

        private async Task<List<Claim>> GetValidClaims(User user)
        {
           var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            return AddRolesToClaim(userRoles, claims);            
        }

        private List<Claim> AddRolesToClaim(IList<string> userRoles, List<Claim> claims) 
        {
            foreach (string userRole in userRoles)
            {
                var rolesClaims = new List<Claim>
                {
                    new Claim("RoleName", userRole),
                };

                claims.AddRange(rolesClaims);
            }

            return claims;
        }
    }
}
