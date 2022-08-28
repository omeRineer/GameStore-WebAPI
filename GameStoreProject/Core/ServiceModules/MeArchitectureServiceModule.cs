using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Identities.Jwt;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using AutoMapper;
using Core.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace Core.ServiceModules
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        private readonly IConfiguration Configuration;
        private readonly TokenOptions TokenOptions;
        private readonly IWebHostEnvironment Environment;
        public MeArchitectureServiceModule(IConfiguration configuration,
                                           IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment=environment;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public void Load(IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidIssuer = TokenOptions.Issuer,
                        ValidAudience = TokenOptions.Audience,
                        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(TokenOptions.SecurityKey)

                    };
                });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddFileTool(x =>
            {
                x.BasePath = $"{Environment.WebRootPath}/Files";
            });

        }
    }
}
