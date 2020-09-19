using System.Net.Http;

namespace NetCore31Skeleton.Core.Utils.Interfaces
{
    public interface IHtttpClientCreator
    {
        HttpClient Create();
    }
}
