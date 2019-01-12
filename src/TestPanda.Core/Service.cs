using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPanda.Core
{
    public class Service
    {
        private readonly IServiceProvider _services;
        public Service()
        {
            IServiceCollection services = new ServiceCollection();
            _services = ConfigureServices(services);
        }

        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestPandaContext>()
                .AddSingleton<TestOperations>();
            return services.BuildServiceProvider();
        }
    }
}
