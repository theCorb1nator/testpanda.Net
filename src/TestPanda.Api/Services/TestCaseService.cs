using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.DomainEntities;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Api
{
    public class TestCaseService
    {
        private readonly TestPandaContext _context;

        public TestCaseService(TestPandaContext context) => _context = context;

        public async Task<TestCase> GetTestCaseAsync(int testCaseId)
        {
            return await _context.TestCases.SingleAsync(x => x.Id == testCaseId);
        }

        public void FailTest(int testId, string reason)
        {
            var test = _context.TestCases.Single(x => x.Id == testId);
            if (!test.Fail(reason).HasErrors) { _context.SaveChanges(); }
        }

        public async Task<IModelState> AddTestCaseAsync(string title, string description)
        {
            var status = new StatusGenericHandler();
            await _context.AddAsync(new TestCase(title, description));
            return status;
        }
    }
}