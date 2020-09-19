using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using NetCore31Skeleton.Core.Localization;

namespace NetCore31Skeleton.WebApi.InternalApi.Extensions
{
    public static class ResourcesExtension
    {
        public static IServiceCollection AddResources(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            return services;
        }
    }
}
