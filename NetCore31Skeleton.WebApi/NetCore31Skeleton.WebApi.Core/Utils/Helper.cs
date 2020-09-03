using System;
using System.Configuration;
using System.Linq;

namespace NetCore31Skeleton.WebApi.Core.Utils
{
    public static class Helper
    {
        public static string GetConfigStr(string key)
        {
            try
            {
                if (ConfigurationManager.AppSettings.Count != 0)
                {
                    if (ConfigurationManager.AppSettings[key] == null)
                        return String.Empty;
                    else
                        return ConfigurationManager.AppSettings[key];
                }
                return String.Empty;

            }
            catch
            {
                return String.Empty;
            }
        }

        public static string GetConfigStr(string key, string defaultStr)
        {
            var str = GetConfigStr(key);
            return str.Length > 0 ? str : defaultStr;
        }

        public static string ToQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + p.GetValue(obj, null).ToString();

            return String.Join("&", properties.ToArray());
        }
    }
}
