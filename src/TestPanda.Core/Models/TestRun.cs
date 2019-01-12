using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPanda.Core
{
    public class TestRun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get;  }
        public TestUser TestedBy { get; set; }
        public ICollection<TestPlan> TestPlans { get; set; }

    }
}