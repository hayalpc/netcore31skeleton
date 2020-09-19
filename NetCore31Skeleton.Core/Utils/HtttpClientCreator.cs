using Microsoft.AspNetCore.Http;
using NetCore31Skeleton.Core.Utils.Interfaces;
using System.Net.Http;

namespace NetCore31Skeleton.Core.Utils
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
