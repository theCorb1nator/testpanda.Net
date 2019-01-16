using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Linq;
using TestPanda.Api.DomainEntities;
using TestPanda.Api.Models;
using TestPanda.Api.Services;

namespace TestPanda.Api
{
    public class Startup
    {
        public static IConfigurationRoot Config;
        public Startup(IHostingEnvironment env)
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connString = Startup.Config["connectionStrings:TestPandaConnectionString"];
            services.AddDbContext<TestPandaContext>(o => o.UseSqlServer(
                connString));
            services.AddScoped<ITestPlanService, TestPlanService>()
                .AddScoped<ITestCaseService, TestCaseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                  {
                      context.Response.StatusCode = 500;
                      await context.Response.WriteAsync("An unexpected fault occured, please try again!");
  
                  });
                });
            }
            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TestPlan, TestPlanModel>()
                .ForMember(dest => dest.NumberOfTestsCompleted, opt => opt.MapFrom(src => src.TestCases
                .ToList().Count()));
                cfg.CreateMap<Models.AddTestPlanModel, TestPlan>();
            });

            app.UseMvc();
        }
    }
}
