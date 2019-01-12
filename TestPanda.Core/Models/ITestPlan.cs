using System;
using System.Collections.Generic;
using System.Text;

namespace TestPanda.Core
{
    public interface ITestPlan : IEntity
    { 
        string Description { get; set; }
        List<ITestCase> TestCases { get; set; }  
    }
}
