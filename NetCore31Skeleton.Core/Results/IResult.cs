namespace NetCore31Skeleton.Core.Results
{
    public interface IResult
    {
        int Code { get; }

        bool Success { get; }

        string Message { get; }

        bool IsSuccess { get; }
    }
}
