using System;
using TestPanda.Core;
using TestPanda.Vsts;
using Xunit;

namespace Vsts.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        public async void VstsService_GetWorkItemById_ReturnsWorkItem(long id)
        {
            var sut = new VstsService();
            var result = sut.GetIssueAsync(id);
            Assert.IsType<Issue>(result);
        }
    }
}
