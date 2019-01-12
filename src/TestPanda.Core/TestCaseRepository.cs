using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPanda.Core
{
    public class TestCaseRepository : IRepository<ITestCase>
    {
        Task IRepository<ITestCase>.AddAsync(ITestCase entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<ITestCase>.DeleteAsync(ITestCase entity)
        {
            throw new NotImplementedException();
        }

        Task<ITestCase> IRepository<ITestCase>.FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ITestCase>> IRepository<ITestCase>.GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<ITestCase>.UpdateAsync(ITestCase entity)
        {
            throw new NotImplementedException();
        }
    }
}
