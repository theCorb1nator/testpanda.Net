using Microsoft.Extensions.DependencyInjection;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Threading.Tasks;

namespace TestPanda.Vsts
{
    public class VstsService
    {
        private IServiceProvider _services;
        private readonly static Uri _accountUri = new Uri("https://dev.azure.com/corbin0941/");
        private readonly static string _pat = "";
        private readonly VssConnection _connection;
        public VstsService()
        {
            _connection = new VssConnection(_accountUri, new VssBasicCredential(string.Empty, _pat));
            IServiceCollection services = new ServiceCollection();
            _services = ConfigureServices(services);
        }

        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
           services.AddSingleton(_connection.GetClient<WorkItemTrackingHttpClient>());
            services.AddSingleton<WorkItemRepository>();
            return services.BuildServiceProvider();
        }

        public async Task<MyWorkItem> GetWorkItemByIdAsync(int id)
        {
            var repo = _services.GetRequiredService<WorkItemRepository>();
            var result = await repo.FindByIdAsync(id);
            return await repo.FindByIdAsync(id);
        }


    }
}
