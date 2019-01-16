using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPanda.Api.Services;
using TestPanda.Api.Models;
using TestPanda.Api.DomainEntities;

namespace TestPanda.Api.Controllers
{
    [Route("api/testplans")]
    public class TestPlansController : Controller
    {
        private readonly ITestPlanService _service;

        public TestPlansController(ITestPlanService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetTestPlansAsync()
        {
            return Ok(await _service.GetTestPlansAsync());
        }

        [HttpGet("{testPlanId}", Name = "GetTestPlan")]
        public async Task<IActionResult> GetTestPlan(int testPlanId)
        {
            var testPlan = await _service.GetTestPlanAsync(testPlanId);
            if (testPlan == null) { return NotFound(); };
            return Ok(await _service.GetTestPlanAsync(testPlanId));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTestPlanAsync([FromBody] AddTestPlanModel testPlan)
        {
            if (testPlan == null) { return BadRequest(); };
            var testPlanModel = await _service.CreateTestPlanAsync(testPlan);
            return CreatedAtRoute("GetTestPlan", new { id = testPlanModel.TestPlanId }, 
                testPlanModel );

        }

    }
}
