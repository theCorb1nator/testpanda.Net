using System;

namespace TestPanda.Core
{
    public interface ITestCase : IEntity
    {
        string Description { get; set; }      
        TestState State { get; set; }
        DateTime LastUpdated { get; set; }
        string Comments { get; set; }
    }
}