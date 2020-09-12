namespace NetCore31Skeleton.WebApi.Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, int code, bool success, string message) : base(code, success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
