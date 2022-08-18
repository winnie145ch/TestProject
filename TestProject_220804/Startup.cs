using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using ClassLibrary2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using TestProject_220804.Models;
using TestProject_220804.Services;

namespace TestProject_220804
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<appsettings>(Configuration);
            services.AddSingleton<ClaimAccessor>();
            services.Configure<setting>(Configuration);
            services.AddSingleton<ClaimSetting>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /*services.AddEntityFrameworkSqlServer().AddDbContext<_DB120999Context>(options =>
            {
                options.UseSqlServer(@"Data Source=10.11.37.148;Initial Catalog=TrainDB120999;Persist Security Info=True;User ID=120999;Password=120999;").EnableSensitiveDataLogging(true);
            });*/
            services.AddEntityFrameworkSqlServer().AddDbContext<_DB120999Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("120999DB")).EnableSensitiveDataLogging(true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
