using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Context;
using NLog;
using System.Configuration;

namespace NetCore31Skeleton.WebApi.Core.Extensions
{
    public static class DbSelectorExtension
    {
        public static IServiceCollection AddDbSelector(this IServiceCollection services)
        {
            var dbEngine = ConfigurationManager.AppSettings["DbEngine"].ToString();
            var conStr = "";
            if (dbEngine.Equals("pgsql"))
            {
                conStr = ConfigurationManager.AppSettings["PgsqlConnectionString"];
                services.AddDbContext<CoreDbContext>(options => options.UseNpgsql(ConfigurationManager.AppSettings["PgsqlConnectionString"]));
            }
            else if (dbEngine.Equals("mssql"))
            {
                conStr = ConfigurationManager.AppSettings["MssqlConnectionString"];
                services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(ConfigurationManager.AppSettings["MssqlConnectionString"]));
            }
            else if (dbEngine.Equals("mysql"))
            {
                conStr = ConfigurationManager.AppSettings["MysqlConnectionString"];
                services.AddDbContext<CoreDbContext>(options => options.UseMySql(ConfigurationManager.AppSettings["MysqlConnectionString"]));
            }
            else if (dbEngine.Equals("memory"))
            {
                conStr = ConfigurationManager.AppSettings["MemoryConnectionString"];
                services.AddDbContext<CoreDbContext>(options => options.UseInMemoryDatabase(ConfigurationManager.AppSettings["MemoryConnectionString"]));
            }

            services.AddScoped<IGenericUnitOfWork<CoreDbContext>, CoreUnitOfWork>();

            GlobalDiagnosticsContext.Set("connectionString", conStr);

            return services;
        }
    }
}
