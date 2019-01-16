using AutoMapper;
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
    public class TestPlanService : ITestPlanService
    {
        private readonly TestPandaContext _context;
        public TestPlanService(TestPandaContext context)
        {
            _context = context;
        }

        public async Task<IModelState> DeleteTestPlanAsync(DeleteTestPlanModel Model)
        {
            throw new NotImplementedException();
        }

        public async Task<TestPlanModel> GetTestPlanAsync(int testPlanId)
        {
            var testPlan = await _context.TestPlans.SingleOrDefaultAsync(x => x.TestPlanId == testPlanId);
            return Mapper.Map<TestPlanModel>(testPlan);

        }

        public async Task<IEnumerable<TestPlanModel>> GetTestPlansAsync()
        {
            var testPlansFromDb = await _context.TestPlans.ToListAsync();
            return Mapper.Map<IEnumerable<TestPlanModel>>(testPlansFromDb);
        }

        public Task<IModelState> UpdateTestPlanAsync(UpdateTestPlanModel Model)
        {
            throw new NotImplementedException();
        }

        public async Task<TestPlanModel> CreateTestPlanAsync(AddTestPlanModel testPlan)
        {
            var testPlanEntity = Mapper.Map<TestPlan>(testPlan);
            var entity = await _context.TestPlans.AddAsync(new TestPlan(testPlan.Title, testPlan.Description));
            await _context.SaveChangesAsync();
            var testPlanModel = Mapper.Map<TestPlanModel>(entity);
            return testPlanModel;
        }
    }
}
