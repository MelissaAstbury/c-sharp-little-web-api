using System;
using ElephantsProject;
using ElephantsProject.Repo;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElephantsTests
{ 
    public class ElephantTests 
    {
        [Fact]
        public async Task GetAll_ReturnsNoElephants()
        {
            // arrange 
            var totalElephantsLength = 0;
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.GetAll()).ReturnsAsync(new List<Elephant>());

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            // act
            var result =  await _tests.GetAll();

            // assert
            Assert.Equal(totalElephantsLength, result.Count);
        }


        [Fact]
        public async Task GetAll_ReturnsAllElephants()
        {
            // arrange 
            var totalElephantsLength = 2;
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.GetAll()).ReturnsAsync(
                new List<Elephant>() {
                    new Elephant() { name = "Bob" },
                    new Elephant() { name = "Billy" }
                });

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            // act
            var result = await _tests.GetAll();

            // assert
            Assert.Equal(totalElephantsLength, result.Count);
        }
    }
}
