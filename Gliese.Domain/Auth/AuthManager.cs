using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Entities.Token;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Generic;
using Gliese.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Domain.Auth
{
    public class AuthManager : IAuthManager
    {         
        private readonly IJwtService _jwt;

        public AuthManager(IJwtService jwt)            
        {                       
            _jwt = jwt;           
        }

        public async Task<string> IsAuthenticated(User user)
        {
            string token = await _jwt.GenerateJwtToken(user);

            return await Task.FromResult(token);
        }       

        /*public string RandomString(int length)
        {
            RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
            byte[] tokenBuffer = new byte[length];
            cryptRNG.GetBytes(tokenBuffer);
            var password = Convert.ToBase64String(tokenBuffer);
            return $"Mc{password}#56";
        }*/
    }
}
