using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Caching.Memory;
using NetCore31Skeleton.Core.Utils.Interfaces;
using NetCore31Skeleton.Library.Log;

namespace NetCore31Skeleton.Core.Utils
{
    public class HttpClientHelper<TRequest, TResponse> : IHttpClientHelper<TRequest, TResponse>
    {
        private HttpClient client;
        private readonly IMemoryCache _memCache;
        private readonly IGenericLogger logger;

        public HttpClientHelper(IHtttpClientCreator htttpClientCreator, IGenericLogger logger, IMemoryCache _memCache)
        {
            this.logger = logger;
            this._memCache = _memCache;
            client = htttpClientCreator.Create();
        }

        public void SetHeader(string key, string value)
        {
            client.DefaultRequestHeaders.Add(key, value);
        }

        public void AddToken(string token)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
       

        public TResponse Get(string baseUrl, string method, string query = null)
        {
            string uri = baseUrl + method;
            if (query != null)
            {
                uri += query;
            }
            var streamTask = client.GetStringAsync(uri);
            var repositories = JsonConvert.DeserializeObject<TResponse>(streamTask.Result);

            return repositories;
        }

        public void GetAsync(string baseUrl, string method, string query = null)
        {
            Task.Run(() =>
            {
                string uri = baseUrl + method;
                if (query != null)
                {
                    uri += query;
                }
                var streamTask = client.GetStringAsync(uri);
            });
        }

        public async Task<HttpResponseMessage> DoPost(string baseUrl, string method, TRequest parameters)
        {
            string content = JsonConvert.SerializeObject(parameters);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PostAsync(uri, byteContent).ConfigureAwait(false);
            return response;
        }

        public TResponse Post(string baseUrl, string method, TRequest parameters)
        {
            string content = JsonConvert.SerializeObject(parameters);
            Task<TResponse> task = DoPostAsync(baseUrl, method, content);
            task.Wait();
            var result = task.Result;
            return result;
        }

        public TResponse Delete(string baseUrl, string method, TRequest deleteDTO)
        {
            string content = JsonConvert.SerializeObject(deleteDTO);
            Task<TResponse> task = DoPostAsync(baseUrl, method, content);
            task.Wait();
            var result = task.Result;
            return result;
        }

        public TResponse Delete(string baseUrl, string method)
        {
            Task<TResponse> task = DoDeletAsync(baseUrl, method);
            task.Wait();
            var result = task.Result;
            return result;
        }

        private async Task<TResponse> DoPostAsync(string baseUrl, string method, string parameters)
        {
            var buffer = Encoding.UTF8.GetBytes(parameters);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PostAsync(uri, byteContent).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //logger.Error(JsonConvert.SerializeObject(response));
            }
            //logger.Error(result);
            if (typeof(TResponse) == typeof(String))
            {
                return JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(result));
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(result);
                return obj;
            }
        }

        public void PostAsync(string baseUrl, string method, TRequest parameters)
        {
            Task.Run(async () =>
            {
                string content = JsonConvert.SerializeObject(parameters);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string uri = baseUrl + method;
                var response = await client.PostAsync(uri, byteContent).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
            });
        }

        private async Task<List<TResponse>> DoPostWithLoadOptions(string baseUrl, string method, string parameters)
        {
            var buffer = Encoding.UTF8.GetBytes(parameters);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PostAsync(uri, byteContent).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<List<TResponse>>(result);
            return obj;
        }

        public TResponse Put(string baseUrl, string method, TRequest parameters)
        {
            string content = JsonConvert.SerializeObject(parameters);
            Task<TResponse> task = DoPutAsync(baseUrl, method, content);
            task.Wait();
            var result = task.Result;
            return result;
        }

        private async Task<TResponse> DoPutAsync(string baseUrl, string method, string parameters)
        {
            var buffer = Encoding.UTF8.GetBytes(parameters);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PutAsync(uri, byteContent).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TResponse>(result);
            return obj;
        }

        private async Task<TResponse> DoDeletAsync(string baseUrl, string method)
        {
            string uri = baseUrl + method;
            var response = await client.DeleteAsync(uri).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TResponse>(result);
            return obj;
        }
    }
}
