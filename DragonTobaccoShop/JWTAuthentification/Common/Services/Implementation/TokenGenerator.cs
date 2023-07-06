using JWTAuthentification.Common.Options;
using JWTAuthentification.Common.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentification.Common.Services.Implementation
{
    public class TokenGenerator : ITokenGenerator
    {
        public JwtSecurityToken GenerateToken(IJWTAuthenticationOptions options, List<Claim> authentificationClaims, DateTime expiresTime)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Secret));

            var token = new JwtSecurityToken(
                options.ValidIssuer,
                options.ValidAudience,
                expires: expiresTime,
                claims: authentificationClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}