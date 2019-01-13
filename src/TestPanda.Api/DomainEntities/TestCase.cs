using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Api.DomainEntities
{
    public class TestCase
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TestState State { get; private set; }
        public string Reason { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public TestUser Author { get; private set; }
        public string Comments { get; private set; }

        public TestCase(string title, string description, TestUser author)
        {
            Title = title;
            Description = description;
            Author = author;
        }


        public IStatusGeneric Fail(string reason)
        {
            var status = new StatusGenericHandler();
            if (string.IsNullOrWhiteSpace(reason))
            {
                status.AddError("You must provide a fail reason.", nameof(reason));
                return status;
            }
            State = TestState.Failed;
            Reason = reason;
            return status;

        }


        public IStatusGeneric PassTest(TestUser user)
        {
            var status = new StatusGenericHandler();
            if (user == null)
            {
                status.AddError("No user provided", nameof(user));
                return status;
            }
            State = TestState.Passed;

            return status;
        }

        public void ResetTest()
        {
            throw new NotImplementedException();
        }

    }
}
