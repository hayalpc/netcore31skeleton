using Microsoft.Extensions.DependencyInjection;
using NetCore31Skeleton.WebApi.Core.Utils;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;

namespace NetCore31Skeleton.WebApi.InternalApi.Extensions
{
    public static class HttpClientUtilsExtension
    {
        public static IServiceCollection AddHttpClientUtils(this IServiceCollection services)
        {
            //services.AddScoped<IHtttpClientCreator, HtttpClientCreator>();
            //services.AddScoped<IHttpClientHelperFactory, HttpClientHelperFactory>();

            return services;
        }
    }
}
