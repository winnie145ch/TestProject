using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TestProject_220804
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, config)=> {
                config
                .AddEnvironmentVariables()
                .AddJsonFile(
                    path: "appsettings.json",
                    optional:false,
                    reloadOnChange:true
                    )
                .AddJsonFile(
                    path: "appsettings.{hostContext.HostingEnviroment.EnviromentName}.json",
                    optional:true,
                    reloadOnChange:true
                    )
                .AddJsonFile(
                    path: "setting.json",
                    optional: true,
                    reloadOnChange: true
                    );
            })
                .UseStartup<Startup>()
                .Build();
    }
}
