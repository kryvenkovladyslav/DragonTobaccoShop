using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System;
using JWTAuthentification.DependencyInjection;
using WebAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Domain.ApplicationModels;
using DataAccessLayer.Common.Data;
using DataAccessLayer.DependencyInjection;
using IdentitySystem.DependencyInjection;
using WebAPI.Infrastructure.Mapping.DependencyInjection;
using JWTAuthentification.Common.Options;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BusinessLayer.Extensions;
using EmailMessaging.Extensions;

namespace WebAPI
{
    public class Startup
    {
        public readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddControllers()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));

            services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.Position));
            services.Configure<OriginsOptions>(configuration.GetSection(OriginsOptions.Position));
            services.Configure<ConnectionStringsOptions>(configuration.GetSection(ConnectionStringsOptions.Position));

            services.AddDbContext<DatabaseContext>((provider, builder) =>
            {
                var option = provider.GetService<IOptions<ConnectionStringsOptions>>().Value;
                builder.UseSqlServer(option.ApplicationConnetion);
            });
            

            services.AddIdentity<User, Role>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            IJWTAuthenticationOptions options = new JWTOptions();
            configuration.GetSection(JWTOptions.Position).Bind(options);
            services.AddJWTAuthentication(options);

            services.AddEmailMessaging();
            services.AddMapperConfiguration();
            services.AddBusinessLayerServices();
            services.AddDefaultIdentitySystemServices<User, Role, Guid>();
            services.TryAddScopedAllApplicationRepositories();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(policy => {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(app.ApplicationServices.GetService<IOptions<OriginsOptions>>().Value.Url);
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeaBattle API"));
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}