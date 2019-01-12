using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPanda.Core
{
    public interface ITestOperations
    {
        Task<bool> UpdateTestStateAsync(TestState state);
    }
}
