namespace NetCore31Skeleton.Core.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(T data, int code, string message) : base(data, code, false, message)
        {

        }
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(int code, string message) : base(default, code, false, message)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
