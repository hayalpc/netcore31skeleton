using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NetCore31Skeleton.WebApi.Core.Extensions;
using NetCore31Skeleton.WebApi.Core.Utils;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;
using NetCore31Skeleton.WebApi.InternalApi.Extensions;
using NetCore31Skeleton.WebApi.InternalApi.Filters;
using NetCore31Skeleton.WebApi.Repository.Seeds;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace NetCore31Skeleton.WebApi.InternalApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new CustomValidateAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMemoryCache();

            services.AddDbSelector();

            services.AddAutoMapper(typeof(Startup));

            services.AddResources();

            services.AddHttpClientUtils();

            services.AddScoped<ITokenCreator, TokenCreator>();

            services.AddTransients();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
                {
                    var secretKey = Helper.GetConfigStr("JwtSecurityKey", "JwtSecurityKey2020");
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                        ValidAudience = Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                        IssuerSigningKey = key,
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/500");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            SeedDatabase.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
        }
    }
}