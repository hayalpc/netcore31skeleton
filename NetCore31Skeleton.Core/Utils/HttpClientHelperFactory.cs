using Microsoft.Extensions.Caching.Memory;
using NetCore31Skeleton.Core.Utils.Interfaces;
using NetCore31Skeleton.Library.Log;

namespace NetCore31Skeleton.Core.Utils
{
    public class HttpClientHelperFactory : IHttpClientHelperFactory
    {

        private readonly IHtttpClientCreator htttpClientCreator;
        private readonly IMemoryCache _memory;
        private readonly IGenericLogger logger;

        public HttpClientHelperFactory(IHtttpClientCreator htttpClientCreator, IGenericLogger logger, IMemoryCache _memory)
        {
            this.htttpClientCreator = htttpClientCreator;
            this.logger = logger;
        }

        public IHttpClientHelper<TRequest, TResponse> Create<TRequest, TResponse>()
        {
            var client = new HttpClientHelper<TRequest, TResponse>(htttpClientCreator, logger, _memory);
            return client;
        }
    }
}
