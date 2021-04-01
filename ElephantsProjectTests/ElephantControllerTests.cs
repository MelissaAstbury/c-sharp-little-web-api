using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ElephantsProject;
using ElephantsProject.Repo;
using ElephantsProjectTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace ElephantsTests
{
    public class ElephantControllerTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client { get; }

        public ElephantControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetAll_Returns200()
        {
            var response = await _client.GetAsync("api/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Get_GivenEmptyElephantId_Return404()
        {
            var response = await _client.GetAsync($"api/elephant/{Guid.Empty}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task Get_GivenElephantId_Return200()
        {
            var response = await _client.GetAsync($"api/elephant/14f661d3-1d3e-4a83-9cd0-87edb15bbd75");

            var stringContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Elephant>(stringContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Black Diamond", result.name);
        }


        [Fact]
        public async Task Post_AddsElephant_Returns200()
        {
            var postRequest = new
            {
                url = "api/elephant",
                body = new
                {
                    id = Guid.NewGuid(),
                    name = "Melissa Astbury",
                    species = "Asian",
                    sex = "Female",
                    dob = 2020,
                    dod = 0,
                    wikilink = "https://en.wikipedia.org/wiki/Black_Diamond_(elephant)",
                    note = "Does this work"
                }
            };

            var postResponse = await _client.PostAsync(postRequest.url, ContentHelper.GetStringContent(postRequest.body));
            var json = await postResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
        }

        [Fact]
        public async Task Post_AddIncompleteElephant_Returns400()
        {
            var postRequest = new
            {
                url = "api/elephant",
                body = new
                {
                    id = Guid.NewGuid(),
                    name = "",
                    species = "Asian",
                    sex = "Female",
                    dob = 2020,
                    dod = 0,
                    wikilink = "https://en.wikipedia.org/wiki/Black_Diamond_(elephant)",
                    note = "Does this work"
                }
            };

            var postResponse = await _client.PostAsync(postRequest.url, ContentHelper.GetStringContent(postRequest.body));
            var json = await postResponse.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }


        [Fact]
        public async Task Delete_GivenElephantId_Return200()
        {
            var response = await _client.DeleteAsync($"api/elephant/14f661d3-1d3e-4a83-9cd0-87edb15bbd75");

            var stringContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Elephant>(stringContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Black Diamond", result.name);
        }


        [Fact]
        public async Task Delete_GivenEmptyElephantId_Return500()
        {
            var response = await _client.DeleteAsync($"api/elephant/{Guid.Empty}");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

    }
}
