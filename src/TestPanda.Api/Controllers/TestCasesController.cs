using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.Models;
using TestPanda.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestPanda.Api.Controllers
{
    [Route("api/testcases")]
    public class TestCasesController : Controller
    {
        private readonly ILogger<TestCasesController> _logger;
        private readonly ITestCaseService _service;

        public TestCasesController(ITestCaseService service, ILogger<TestCasesController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{testCaseId}")]
        public async Task<IActionResult> GetTestCases(int testCaseId)
        {
            _logger.LogInformation($"Get Test Case {testCaseId}");
            var testCase = await _service.GetTestCaseAsync(testCaseId);
            return new JsonResult(testCase);
        }
    }
}
