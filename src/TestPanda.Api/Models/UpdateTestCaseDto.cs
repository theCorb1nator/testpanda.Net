namespace TestPanda.Api.Services
{
    public class UpdateTestCaseStateDto
    {
        public int TestCaseId { get; set; }
        public string Title { get; set; }
        public string State { get; internal set; }
        //TODO Add who updated the test state 
    }
}