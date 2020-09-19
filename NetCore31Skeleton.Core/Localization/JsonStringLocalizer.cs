using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace NetCore31Skeleton.Core.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        List<JsonLocalization> localization = new List<JsonLocalization>();
        public JsonStringLocalizer()
        {
            //read all json file
            JsonSerializer serializer = new JsonSerializer();
            localization = JsonConvert.DeserializeObject<List<JsonLocalization>>(File.ReadAllText(@"Messages.json"));
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return localization.Where(l => l.Value.Keys.Any(lv => lv == Thread.CurrentThread.CurrentCulture.Name)).Select(l => new LocalizedString(l.Key, l.Value[Thread.CurrentThread.CurrentCulture.Name], true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new JsonStringLocalizer();
        }

        private string GetString(string name)
        {
            var query = localization.Where(l => l.Value.Keys.Any(lv => lv == Thread.CurrentThread.CurrentCulture.Name));
            var value = query.FirstOrDefault(l => l.Key == name);
            return value.Value[Thread.CurrentThread.CurrentCulture.Name];
        }
    }
}
