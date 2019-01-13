using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TestPanda.Api.DomainEntities;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TestPlan, TestPlanDto>();
            });

            app.UseMvc();
        }
    }
}
