using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;

namespace zbrozonoidWebService
{
    public class Program
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "zbrozonoidWebService.log" };
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Debug, logfile);
            LogManager.Configuration = config;

            Logger.Info("start");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
