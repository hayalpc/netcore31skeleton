namespace NetCore31Skeleton.Core.Utils.Interfaces
{
    public interface IHttpClientHelperFactory
    {
        IHttpClientHelper<TRequest, TResponse> Create<TRequest, TResponse>();
    }
}
