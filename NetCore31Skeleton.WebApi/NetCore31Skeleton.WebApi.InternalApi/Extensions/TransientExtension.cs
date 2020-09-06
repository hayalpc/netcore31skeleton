using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.WebApi.Business;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Interfaces;

namespace NetCore31Skeleton.WebApi.InternalApi.Extensions
{
    public static class TransientExtension
    {
        public static IServiceCollection AddTransients(this IServiceCollection services)
        {
            #region Business
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<INoteBusiness, NoteBusiness>();
            services.AddTransient<ITransactionBusiness, TransactionBusiness>();
            #endregion Business

            #region Repository
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            #endregion Repository

            #region Logger
            services.AddTransient<IGenericLogger, NLogLogger>();
            #endregion Logger

            return services;
        }
    }
}
