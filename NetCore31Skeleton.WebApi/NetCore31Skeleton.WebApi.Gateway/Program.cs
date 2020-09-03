using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace NetCore31Skeleton.WebApi.Gateway
{
    public class Program
    {
        private static IConfiguration _configuration;

        public static void Main(string[] args)
        {
            string URL = ConfigurationManager.AppSettings["GatewayUrl"];

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

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
                config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
                config.AddJsonFile("appsettings.json", true, true);
                config.AddJsonFile("ocelot.json");
                config.AddEnvironmentVariables(prefix: "ASPNETCORE_");

                _configuration = config.Build();
            })
            .ConfigureServices(s =>
            {
                s.AddOcelot(_configuration);
            })
            .Configure(app =>
            {
                app.UseOcelot().Wait();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();

                logging.AddConsole();
            })
            .UseIIS()
            .UseIISIntegration()
            .UseUrls(URL)
            .Build();

            if (isWindows && isService && !URL.Contains("localhost"))
                host.RunAsService();
            else
                host.Run();
        }
     
    }
}
