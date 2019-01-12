using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TestPanda.Core.Enums;

namespace TestPanda.Core
{
    public class TestCase
    {
        private readonly TestPandaContext _context;
        public TestCase(TestPandaContext context)
        {
            _context = context;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Description { get; set; }
        public TestState State { get; set; }
        public string Reason { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Comments { get; set; }
        public Block ActiveBlock { get; set; }


        public void FailTest(string reason)
        {
            var test = _context.Tests.FirstOrDefault(x => x.Id == Id);
            test.State = TestState.Failed;
            test.Reason = reason;
            _context.SaveChanges();
        }
        public void BlockTest(Block block)
        {
            throw new NotImplementedException();
        }


        public void PassTest()
        {
            throw new NotImplementedException();
        }

        public void ResetTest()
        {
            throw new NotImplementedException();
        }

    }
}
