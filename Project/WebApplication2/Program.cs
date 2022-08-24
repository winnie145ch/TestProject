using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
                .Build();
    }
}
