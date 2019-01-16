using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.ErrorHandling;
using TestPanda.Api.Models;

namespace TestPanda.Api.Services
{
    public interface ITestCaseService
    {
        Task<TestCaseModel> GetTestCaseAsync(int testCaseId);
        Task<IEnumerable<TestCaseModel>> GetTestCasesAsync();
        Task<TestCaseModel> AddTestCaseAsync(AddTestCaseModel Model);
        Task<IModelState> MarkTestAsFailedAsync(UpdateTestCaseStateModel Model);
        Task<IModelState> MarkTestAsPassedAsync(UpdateTestCaseStateModel Model);
        Task<IModelState> MarkTestAsActiveAsync(UpdateTestCaseStateModel Model);

    }
}
