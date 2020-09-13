using System;
using System.Configuration;
using System.Linq;
using System.Text;

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

        // iç içe array için düzeltme yap
        public static string ToQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + p.GetValue(obj, null).ToString();

            return String.Join("&", properties.ToArray());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
