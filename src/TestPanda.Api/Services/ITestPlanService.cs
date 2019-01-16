using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.ErrorHandling;
using TestPanda.Api.Models;

namespace TestPanda.Api.Services
{
    public interface ITestPlanService
    {
        Task<TestPlanModel> GetTestPlanAsync(int testPlanId);
        Task<IEnumerable<TestPlanModel>> GetTestPlansAsync();
        Task<IModelState> UpdateTestPlanAsync(UpdateTestPlanModel planModel);
        Task<IModelState> DeleteTestPlanAsync(DeleteTestPlanModel planModel);
        Task<TestPlanModel> CreateTestPlanAsync(AddTestPlanModel planModel);
    }
}
