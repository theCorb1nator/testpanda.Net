using System;
using System.Collections.Generic;
using System.Text;
using TestPanda.Core.Models;

namespace TestPanda.Core.Interfaces
{
    public interface ITestOperations
    {
        void PassTest();
        void FailTest();
        void BlockTest(Block block);
        void ResetTest();
    }
}
