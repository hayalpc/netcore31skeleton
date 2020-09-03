using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore31Skeleton.WebApi.MigrationTool.Context;

namespace NetCore31Skeleton.WebApi.MigrationTool
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var dbEngine = Configuration.GetValue<string>("DbEngine");
            if (dbEngine.Equals("pgsql"))
            {
                services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PgsqlConnectionString"), options => options.MigrationsAssembly("NetCore31Skeleton.WebApi.MigrationTool")));
            }
            else if (dbEngine.Equals("mssql"))
            {
                services.AddDbContext<MigrationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MssqlConnectionString"), options => options.MigrationsAssembly("NetCore31Skeleton.WebApi.MigrationTool")));
            }
            else if (dbEngine.Equals("mysql"))
            {
                services.AddDbContext<MigrationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MysqlConnectionString"), options => options.MigrationsAssembly("NetCore31Skeleton.WebApi.MigrationTool")));
            }
            else if (dbEngine.Equals("memory"))
            {
                services.AddDbContext<MigrationDbContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("MemoryConnectionString")));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
