using System;
using ElephantsProject;
using Microsoft.AspNetCore.Mvc;
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


        [Fact]
        public void ReturnsElephant_WhenElephantIdIsCalled()
        {
            var validElephantId = "14f661d3-1d3e-4a83-9cd0-87edb15bbd75";

            var result = _tests.GetElephant(validElephantId);

            Assert.Equal(validElephantId, result.id);
        }
    }
}
