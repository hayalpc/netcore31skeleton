namespace NetCore31Skeleton.Core.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }

        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult(int code, string message) : base(code, false, message)
        {

        }
    }
}
