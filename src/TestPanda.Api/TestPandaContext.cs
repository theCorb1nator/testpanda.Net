using Microsoft.EntityFrameworkCore;
using TestPanda.Api.DomainEntities;

namespace TestPanda.Api
{
    public class TestPandaContext : DbContext
    {
        public TestPandaContext(DbContextOptions<TestPandaContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<TestPlan> TestPlans { get; set; }
    }
}
