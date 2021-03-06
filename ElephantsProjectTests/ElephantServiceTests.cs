using ElephantsProject;
using ElephantsProject.Repo;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ElephantsTests
{
    public class ElephantServiceTests
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
            var result = await _tests.GetAll();

            // assert
            Assert.Equal(totalElephantsLength, result.Count);
            mockElephantRepo.VerifyAll();
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
            mockElephantRepo.VerifyAll();
        }


        [Fact]
        public async Task Get_ReturnsElephantById()
        {
            var expectedId = "12345";
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.Get(expectedId)).ReturnsAsync(
                new Elephant() { id = "12345" }
                );

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            var result = await _tests.Get(expectedId);

            Assert.Equal(expectedId, result.id);
            mockElephantRepo.VerifyAll();
        }


        [Fact]
        public async Task Get_ReturnsNullWhenIdIsNotFound()
        {
            var inputId = "67890";
            Elephant elephantResult = null;
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.Get(inputId)).ReturnsAsync(
                elephantResult
                );

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            var result = await _tests.Get(inputId);

            Assert.Null(result);
            mockElephantRepo.VerifyAll();
        }


        [Fact]
        public async Task Delete_ReturnsDeletedElephantById()
        {
            var expectedId = "12345";
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.Delete(expectedId)).ReturnsAsync(
                new Elephant() { id = "12345" }
                );

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            var result = await _tests.Delete(expectedId);

            Assert.Equal(expectedId, result.id);
            mockElephantRepo.VerifyAll();
        }


        [Fact]
        public async Task Delete_ReturnsNullWhenIdIsNotFound()
        {
            var inputId = "67890";
            Elephant elephantResult = null;
            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.Delete(inputId)).ReturnsAsync(
                elephantResult
                );

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            var result = await _tests.Delete(inputId);

            Assert.Null(result);
            mockElephantRepo.VerifyAll();
        }


        [Fact]
        public async Task Post_ReturnsAddedElephantToListOfElephants()
        {
            var newElephant = new Elephant() { name = "Andrew" };
            var returnedElephant = newElephant;
            returnedElephant.id = Guid.NewGuid().ToString();

            var mockElephantRepo = new Mock<IElephantRepo>();
            mockElephantRepo.Setup(x => x.Add(newElephant)).ReturnsAsync(
                returnedElephant
                );

            ElephantService _tests = new ElephantService(mockElephantRepo.Object);

            var result = await _tests.Add(newElephant);

            Assert.Equal(newElephant.name, result.name);
            Assert.NotNull(result.id);
        }
    }
}
