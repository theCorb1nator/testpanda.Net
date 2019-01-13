using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Api.Services
{
    public class TestPlanService : ITestPlanService
    {
        private readonly TestPandaContext _context;
        public TestPlanService(TestPandaContext context)
        {
            _context = context;
        }

        public Task<IModelState> DeleteTestPlanAsync(DeleteTestPlanDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TestPlanDto> GetTestPlanAsync(int testPlanId)
        {
            var testplanDto = new TestPlanDto();
            var testplanET = _context.TestPlans.SingleOrDefaultAsync(x => x.Id == testPlanId);
            testplanDto
        }

        public Task<IEnumerable<TestPlanDto>> GetTestPlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IModelState> UpdateTestPlanAsync(UpdateTestPlanDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
