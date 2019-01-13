using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestPanda.Api.Controllers
{
    [Route("api/testcases")]
    public class TestCasesController : Controller
    {
        private readonly TestPandaContext _context;
        private readonly ILogger<TestCasesController> _logger;

        public TestCasesController(TestPandaContext context, ILogger<TestCasesController> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet()]
        public IActionResult GetTestCases()
        {
            var context = _context.TestCases.ToList();
            List<TestCaseDto> testCases = new List<TestCaseDto>();
            foreach (var test in context)
            {
                testCases.Add(new TestCaseDto()
                {
                    Id = test.Id,
                    Description = test.Description,
                    Title = test.Title,
                    State = test.State.ToString()
                });
            }
            return new JsonResult(testCases);
        }

        [HttpGet("{testCaseId}")]
        public IActionResult GetTestCases(int testCaseId)
        {
            _logger.LogInformation($"Get Test Case {testCaseId}");
            var testCase = _context.TestCases.Single(x => x.Id == testCaseId);
            return new JsonResult(testCase);
        }
    }
}
