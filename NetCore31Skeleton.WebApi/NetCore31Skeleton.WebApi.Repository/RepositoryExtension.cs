using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Repository
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repository
            services.AddTransient<ICoreRepository<Category, long>, CoreRepository<Category, long>>();
            services.AddTransient<ICoreRepository<Note, long>, CoreRepository<Note, long>>();
            services.AddTransient<ICoreRepository<Transaction, long>, CoreRepository<Transaction, long>>();

            services.AddTransient<ICoreRepository<AppUser, int>, CoreRepository<AppUser, int>>();
            services.AddTransient<ICoreRepository<AppUserRole, int>, CoreRepository<AppUserRole, int>>();
            services.AddTransient<ICoreRepository<AppRole, int>, CoreRepository<AppRole, int>>();
            #endregion Repository
        }
    }
}
