using System;
using System.Collections.Generic;
using System.Text;

namespace TestPanda.Core
{
    public class TestCase : ITestCase
    {
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TestState State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastUpdated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Comments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Id => throw new NotImplementedException();
    }
}
