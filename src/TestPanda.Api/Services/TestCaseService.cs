using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.DomainEntities;
using TestPanda.Api.ErrorHandling;
using TestPanda.Api.Models;

namespace TestPanda.Api.Services
{
    public class TestCaseService : ITestCaseService
    {
        private readonly TestPandaContext _context;

        public TestCaseService(TestPandaContext context) => _context = context;

        public async Task<TestCaseModel> GetTestCaseAsync(int testCaseId)
        {
            throw new NotImplementedException();
            //return await _context.TestCases.SingleAsync(x => x.TestCaseId == testCaseId);
        }

        public void FailTest(int testId, string reason)
        {
            var test = _context.TestCases.Single(x => x.TestCaseId == testId);
            if (!test.Fail(reason).HasErrors) { _context.SaveChanges(); }
        }

        public Task<IEnumerable<TestCaseModel>> GetTestCasesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TestCaseModel> AddTestCaseAsync(AddTestCaseModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<IModelState> MarkTestAsFailedAsync(UpdateTestCaseStateModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<IModelState> MarkTestAsPassedAsync(UpdateTestCaseStateModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<IModelState> MarkTestAsActiveAsync(UpdateTestCaseStateModel Model)
        {
            throw new NotImplementedException();
        }
    }
}