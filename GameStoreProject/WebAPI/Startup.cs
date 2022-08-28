using AutoMapper;
using Business.Mapping.Automapper.Profiles;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.Helpers;
using Core.Utilities.Identities.Jwt;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public TokenOptions TokenOptions;
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddServiceModules(new IServiceModule[]
            {
                new StaticServiceModule(),
                new MeArchitectureServiceModule(Configuration,Environment)
            });

            services.AddAutoMapper(x =>
            {
                var profiles = new List<Profile>
                {
                    new MapProfile()
                };

                x.AddProfiles(profiles);
            });



            services.AddCors(options =>
                        options.AddDefaultPolicy(builder =>
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseCors();

            app.UseStaticFiles();

            app.UseCustomTransaction();

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
