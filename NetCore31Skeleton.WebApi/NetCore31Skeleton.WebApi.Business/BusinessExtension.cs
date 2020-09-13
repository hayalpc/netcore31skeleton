using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.WebApi.Business.Concrete;
using NetCore31Skeleton.WebApi.Business.Interfaces;

namespace NetCore31Skeleton.WebApi.Business
{
    public static class BusinessExtension
    {
        public static void AddBusinesses(this IServiceCollection services)
        {
            #region Business
            services.AddTransient<ITransactionBusiness, TransactionBusiness>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IRoleBusiness, RoleBusiness>();
            services.AddTransient<IUserRoleBusiness, UserRoleBusiness>();
            #endregion Business
        }

    }
}
