using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NetCore31Skeleton.Core.Utils;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.WebApi.Business;
using NetCore31Skeleton.WebApi.Business.Concrete;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Extensions;
using NetCore31Skeleton.WebApi.InternalApi.Extensions;
using NetCore31Skeleton.WebApi.InternalApi.Filters;
using NetCore31Skeleton.WebApi.Repository;
using Newtonsoft.Json.Serialization;
using NLog;
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
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbSelector();
            services.AddHttpClientUtils();

            services.AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();

            services.AddSingleton<ITokenCreator, TokenCreator>();
            services.AddResources();

            services.AddBusinesses();
            services.AddRepositories();

            services.AddTransient<IGenericLogger, NLogLogger>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                        ValidAudience = Helper.GetConfigStr("InternalApiUrl", "http://localhost:63939/"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Helper.GetConfigStr("JwtSecurityKey", "JwtSecurityKey2020"))),
                    };
                });

            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new ValidModelAttribute());
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                GlobalDiagnosticsContext.Set("configDir", Helper.GetConfigStr("configDir", "C:\\Logs"));

                app.UseDeveloperExceptionPage();
            }
            else
            {
                GlobalDiagnosticsContext.Set("configDir", Helper.GetConfigStr("configDir", "C:\\Logs"));

                app.UseExceptionHandler("/error/500");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

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
