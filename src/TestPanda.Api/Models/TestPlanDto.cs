using System;
using System.Collections.Generic;

namespace TestPanda.Api
{
    public class TestPlanDto
    {
        public int TestPlanId { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfTestsCompleted { get; set;  }
        public ICollection<TestCaseDto> TestCases { get; set; }
        = new List<TestCaseDto>();

    }
}