namespace NetCore31Skeleton.Core.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(string message) : base(0, true, message)
        {

        }
    }
}
