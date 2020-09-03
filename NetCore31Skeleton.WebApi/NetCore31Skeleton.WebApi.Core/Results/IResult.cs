namespace NetCore31Skeleton.WebApi.Core.Results
{
    public interface IResult
    {
        int Code { get; }

        bool Success { get; }

        string Message { get; }
    }
}
