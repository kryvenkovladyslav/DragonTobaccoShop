using JWTAuthentification.Common.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWTAuthentification.Common.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public JwtSecurityToken GenerateToken(IJWTAuthenticationOptions options, List<Claim> authentificationClaims, DateTime expiresTime);
    }
}