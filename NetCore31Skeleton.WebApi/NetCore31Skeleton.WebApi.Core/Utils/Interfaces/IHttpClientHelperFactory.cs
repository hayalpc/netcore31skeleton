namespace NetCore31Skeleton.WebApi.Core.Utils.Interfaces
{
    public interface IHttpClientHelperFactory
    {
        IHttpClientHelper<TRequest, TResponse> Create<TRequest, TResponse>();
    }
}
