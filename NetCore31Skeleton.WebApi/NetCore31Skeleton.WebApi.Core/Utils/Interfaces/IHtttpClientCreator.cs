using System.Net.Http;

namespace NetCore31Skeleton.WebApi.Core.Utils.Interfaces
{
    public interface IHtttpClientCreator
    {
        HttpClient Create();
    }
}
