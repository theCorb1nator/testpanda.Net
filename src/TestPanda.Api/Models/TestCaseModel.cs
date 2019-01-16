using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPanda.Api.Models
{
    public class TestCaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
        public TestPlanModel TestPlan { get; set; }
    }
}
