using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;

namespace NetCore31Skeleton.WebApi.Core.Utils
{
    public class HttpClientHelperFactory : IHttpClientHelperFactory
    {

        private readonly IHtttpClientCreator htttpClientCreator;
        private readonly IMemoryCache _memory;
        private readonly ILogger logger;

        public HttpClientHelperFactory(IHtttpClientCreator htttpClientCreator, ILogger logger, IMemoryCache _memory)
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
