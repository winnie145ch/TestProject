using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication2.Helpers.Middlewares;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostcontext, config) => {
                config
                .AddEnvironmentVariables()
                .AddJsonFile(
                    path: "settings.json",
                    optional: false,
                    reloadOnChange: true
                    )
                .AddJsonFile(
                    path: $"settings.{hostcontext.HostingEnvironment.EnvironmentName}.json",
                    optional: true,
                    reloadOnChange: true
                    );
            })
                .UseStartup<Startup>()
                .ConfigureLogging(logging => {
                logging.AddProvider(new Log4netProvider("log4net.config"));
            })
                .Build();
        private static void LoadLog4netConfig()
        {
            var repository = LogManager.CreateRepository(
                    Assembly.GetEntryAssembly(),
                    typeof(log4net.Repository.Hierarchy.Hierarchy)
                );
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }
    }
}
