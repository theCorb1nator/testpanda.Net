﻿namespace TestPanda.Api.Services
{
    public class AddTestCaseDto
    {
        public int TestPlanId { get; set; }
        public string Title { get; set;  }
        public string Description { get; set; }     
    }
}