using JWTAuthentification.Common.Options;
using JWTAuthentification.Common.Services.Implementation;
using JWTAuthentification.Common.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentification.DependencyInjection
{
    public static class JWTAuthenticationServiceCollectionExtensions
    {
        public static void AddJWTAuthenticationOptions(this IServiceCollection services, IJWTAuthenticationOptions authenticationOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = authenticationOptions.ValidAudience,
                    ValidIssuer = authenticationOptions.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions.Secret))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
      
        public static void AddTokenGenerator<TImplementation>(this IServiceCollection services)
            where TImplementation : class, ITokenGenerator
        {
            services.TryAddSingleton<ITokenGenerator, TImplementation>();
        }

        public static void AddJWTAuthentication(this IServiceCollection services, IJWTAuthenticationOptions authenticationOptions)
        {
            services.AddJWTAuthenticationOptions(authenticationOptions);
            services.AddTokenGenerator<TokenGenerator>();
        }
    }
}