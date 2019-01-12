using System;
using TestPanda.Vsts;
using Xunit;

namespace Vsts.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        public async void VstsService_GetWorkItemById_ReturnsWorkItem(int id)
        {
            var sut = new VstsService();
            var result = sut.GetWorkItemByIdAsync(id);
            //Assert.IsType<MyWorkItem>(result);
        }
    }
}
