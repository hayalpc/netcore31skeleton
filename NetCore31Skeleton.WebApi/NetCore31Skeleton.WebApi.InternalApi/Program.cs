using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace NetCore31Skeleton.WebApi.InternalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string URL = ConfigurationManager.AppSettings["InternalApiUrl"];

            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            //var webHostArgs = args.Where(arg => arg != "--console").ToArray();

            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            var host = new WebHostBuilder()
            .UseKestrel(
            o =>
            {
                o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(15);
                o.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(30);
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();

                logging.AddConsole();
            })
            .UseIIS()
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseUrls(URL)
            //.UseNLog()
            .Build();

            if (isWindows && isService && !URL.Contains("localhost"))
                host.RunAsService();
            else
                host.Run();
        }

    }
}
