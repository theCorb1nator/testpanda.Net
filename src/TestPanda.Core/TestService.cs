using System.Linq;
using TestPanda.Core;

public class TestService
{
    private readonly TestPandaContext _context;

    public TestService(TestPandaContext context) => _context = context;

    public void MarkTestAsFailed(int testId, string reason)
    {
        var test = _context.Tests.Single(x => x.Id == testId);
        test.Fail();
        _context.SaveChanges();
    }
}