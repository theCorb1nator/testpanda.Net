using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPanda.Api.DomainEntities
{
    public class TestPlan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestPlanId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public TestUser Author { get; private set; }
        public TestUser UpdatedBy { get; private set; }

        public IEnumerable<TestCase> TestCases { get; private set; }

        public TestPlan(string title, string description)
        {
            Title = title;
            Description = description;
            DateCreated = DateTime.Now;

        }
    }
}