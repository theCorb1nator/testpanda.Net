using System;
using System.Collections.Generic;

namespace TestPanda.Api.Models
{
    public class TestPlanModel
    {
        public int TestPlanId { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public int NumberOfTestsCompleted { get; set; }
        public ICollection<TestCaseModel> TestCases { get; set; }
        = new List<TestCaseModel>();

    }
}