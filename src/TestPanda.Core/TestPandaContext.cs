using Microsoft.EntityFrameworkCore;

namespace TestPanda.Core
{
    public class TestPandaContext : DbContext
    {
        public TestPandaContext(DbContextOptions<TestPandaContext> options)
           : base(options)
        { }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestCase> Tests { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<TestPlan> TestPlans { get; set; }



    }
}
