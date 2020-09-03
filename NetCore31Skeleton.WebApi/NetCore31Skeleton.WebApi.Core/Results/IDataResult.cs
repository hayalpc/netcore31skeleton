namespace NetCore31Skeleton.WebApi.Core.Results
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
