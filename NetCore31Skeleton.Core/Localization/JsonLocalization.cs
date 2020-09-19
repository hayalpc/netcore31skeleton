using System.Collections.Generic;

namespace NetCore31Skeleton.Core.Localization
{
    public class JsonLocalization
    {
        public string Key { get; set; }
        public Dictionary<string, string> Value = new Dictionary<string, string>();

    }
}
