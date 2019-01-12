using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPanda.Core
{
    public interface IIssueTrackingService
    {
        Task<bool> UpdateIssueAsync(Issue issue);
        Issue GetIssueAsync(long Id);
        Task<List<Issue>> GetIssuesAsync();
        Task<List<Issue>> GetIssuesAsync(Query query);
    }
}
