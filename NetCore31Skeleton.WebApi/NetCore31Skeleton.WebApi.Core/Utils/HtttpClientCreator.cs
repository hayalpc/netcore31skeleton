using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NetCore31Skeleton.WebApi.Core.Utils
{
    public class HtttpClientCreator : IHtttpClientCreator
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private HttpClient client;

        public HtttpClientCreator(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }

        public HttpClient Create()
        {
            this.client = new HttpClient();
            //if (_memCache.TryGetValue("BearerToken", out string bearerToken))
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            //}
            this.client.Timeout = System.TimeSpan.FromSeconds(15);
            return this.client;
        }

    }
}
