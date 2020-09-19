using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Core.Utils.Interfaces
{
    public interface IHttpClientHelper<TRequest, TResponse>
    {
        void SetHeader(string key, string value);
        void AddToken(string token);
        TResponse Get(string baseUrl, string method, string query = null);
        void GetAsync(string baseUrl, string method, string query = null);
        Task<HttpResponseMessage> DoPost(string baseUrl, string method, TRequest parameters);
        TResponse Post(string baseUrl, string method, TRequest parameters);
        void PostAsync(string baseUrl, string method, TRequest parameters);
        TResponse Delete(string baseUrl, string method, TRequest deleteDTO);
        TResponse Delete(string baseUrl, string method);
        TResponse Put(string baseUrl, string method, TRequest parameters);
    }
}
