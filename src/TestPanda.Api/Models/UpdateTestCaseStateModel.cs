namespace TestPanda.Api.Models
{
    public class UpdateTestCaseStateModel
    {
        public int TestCaseId { get; set; }
        public string Title { get; set; }
        public string State { get; internal set; }
        //
        //TODO Add who updated the test state 
    }
}