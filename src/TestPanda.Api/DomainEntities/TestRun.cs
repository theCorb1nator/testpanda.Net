using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPanda.Api.DomainEntities
{
    public class TestRun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; private set; }

        [ForeignKey("TestUserId")]
        public TestUser Tester { get; private set; }
        public int TestUserId { get; private set; }
        public IEnumerable<TestPlan> TestPlans { get; private set; }

    }
}