using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Context;
using System.Configuration;

namespace NetCore31Skeleton.WebApi.Core.Extensions
{
    public static class DbSelectorExtension
    {
        public static IServiceCollection AddDbSelector(this IServiceCollection services)
        {
            var dbEngine = ConfigurationManager.AppSettings["DbEngine"].ToString();
            if (dbEngine.Equals("pgsql"))
            {
                services.AddDbContext<CoreDbContext>(options => options.UseNpgsql(ConfigurationManager.AppSettings["PgsqlConnectionString"]));
            }
            else if (dbEngine.Equals("mssql"))
            {
                services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(ConfigurationManager.AppSettings["MssqlConnectionString"]));
            }
            else if (dbEngine.Equals("mysql"))
            {
                services.AddDbContext<CoreDbContext>(options => options.UseMySql(ConfigurationManager.AppSettings["MysqlConnectionString"]));
            }
            else if (dbEngine.Equals("memory"))
            {
                services.AddDbContext<CoreDbContext>(options => options.UseInMemoryDatabase(ConfigurationManager.AppSettings["MemoryConnectionString"]));
            }

            services.AddScoped<IGenericUnitOfWork<CoreDbContext>, CoreUnitOfWork>();

            return services;
        }
    }
}
