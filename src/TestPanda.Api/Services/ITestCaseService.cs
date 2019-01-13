using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Api.Services
{
    public interface ITestCaseService
    {
        Task<TestCaseDto> GetTestCaseAsync();
        Task<IEnumerable<TestCaseDto>> GetTestCasesAsync();
        Task<TestCaseDto> AddTestCaseAsync(AddTestCaseDto);
        Task<IModelState> MarkTestAsFailedAsync(UpdateTestCaseStateDto dto);
        Task<IModelState> MarkTestAsPassedAsync(UpdateTestCaseStateDto dto);
        Task<IModelState> MarkTestAsActiveAsync(UpdateTestCaseStateDto dto);

    }
}
