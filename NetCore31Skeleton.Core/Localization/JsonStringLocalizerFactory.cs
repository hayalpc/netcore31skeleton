using Microsoft.Extensions.Localization;
using System;

namespace NetCore31Skeleton.Core.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer();
        }
    }
}
