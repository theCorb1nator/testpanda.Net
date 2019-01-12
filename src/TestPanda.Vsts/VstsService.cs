using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Core;

namespace TestPanda.Vsts
{
    public class VstsService : IIssueTrackingService
    {
        private IServiceProvider _services;
        private readonly IConfiguration _config;
        private readonly VssConnection _connection;
        private readonly WorkItemTrackingHttpClient _client;
        public VstsService()
        {
            _config = new ConfigurationBuilder().AddJsonFile("vsts.json").Build();
            _connection = new VssConnection(new Uri(_config["uri"]), new VssBasicCredential(string.Empty, _config["pat"]));
            IServiceCollection services = new ServiceCollection();
            _services = ConfigureServices(services);
            _client = _services.GetRequiredService<WorkItemTrackingHttpClient>();
        }

        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_connection.GetClient<WorkItemTrackingHttpClient>());
            return services.BuildServiceProvider();
        }

        public Task<bool> UpdateIssueAsync(Issue issue)
        {
            throw new NotImplementedException();
            //_client.UpdateWorkItemAsync();
        }

        public Issue GetIssueAsync(long id)
        {
          
            WorkItem wi = _client.GetWorkItemAsync((int)id).Result;
            var issue = new Issue();
            //{
            //    IssueId = wi.Id.GetValueOrDefault()
            //};
            return issue;
        }

        public Task<List<Issue>> GetIssuesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Issue>> GetIssuesAsync(Query query)
        {
            throw new NotImplementedException();
        }
    }
}
