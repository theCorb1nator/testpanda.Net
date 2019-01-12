using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using TestPanda.Core;

namespace TestPanda.Vsts
{
    public class WorkItemRepository : IRepository<MyWorkItem>
    {
        private readonly WorkItemTrackingHttpClient _client;
        public WorkItemRepository(WorkItemTrackingHttpClient client)
        {
            _client = client;
        }

        public async Task AddAsync(MyWorkItem entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(MyWorkItem entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MyWorkItem> FindByIdAsync(int id)
        {
            MyWorkItem wi = new MyWorkItem();
            try
            {
                // Get the specified work item
                WorkItem workitem = _client.GetWorkItemAsync(id).Result;

                // Output the work item's field values
                foreach (var field in workitem.Fields)
                {
                    Console.WriteLine("  {0}: {1}", field.Key, field.Value);
                }
            }
            catch (AggregateException aex)
            {
                VssServiceException vssex = aex.InnerException as VssServiceException;
                if (vssex != null)
                {
                    Console.WriteLine(vssex.Message);
                }
            }
            return wi;
        }

        public async Task UpdateAsync(MyWorkItem entity)
        {
            throw new NotImplementedException();
            //_client.UpdateWorkItemAsync(entity.Id,);
        }

        public async Task<IEnumerable<MyWorkItem>> GetItemsAsync()
        {
            throw new NotImplementedException();
            //return await _client.GetWorkItemsAsync()
        }
    }
}
