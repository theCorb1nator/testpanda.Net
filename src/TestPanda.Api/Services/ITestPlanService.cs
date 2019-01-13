using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Api.Services
{
    public interface ITestPlanService
    {
        Task<TestPlanDto> GetTestPlanAsync(int testPlanId);
        Task<IEnumerable<TestPlanDto>> GetTestPlansAsync();
        Task<IModelState> UpdateTestPlanAsync(UpdateTestPlanDto dto);
        Task<IModelState> DeleteTestPlanAsync(DeleteTestPlanDto dto);       
    }
}
