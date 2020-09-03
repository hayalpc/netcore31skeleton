using Newtonsoft.Json;

namespace NetCore31Skeleton.WebApi.Core.Results
{
    public class Result : IResult
    {
        public Result(int code, bool success, string message) : this(success, message)
        {
            Code = code;
        }
        public Result(bool success, string message) : this(success)
        {

            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; }
    }
}
