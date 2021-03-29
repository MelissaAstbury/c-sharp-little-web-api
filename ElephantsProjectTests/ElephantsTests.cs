using System;
using ElephantsProject;
using Xunit;

namespace ElephantsTests
{
    public class ElephantsProjectTests
    {
        internal ElephantService _tests = new ElephantService();
    }

    public class ElephantTests : ElephantsProjectTests
    {
        [Fact]
        public void LoadsAllElephantsWithExpectedValues()
        {
            // arrange 
            var totalElephantsLength = 25;

            // act
            var result = _tests.GetElephants();

            // assert
            Assert.Equal(totalElephantsLength, result.Count);
        }
    }
}
