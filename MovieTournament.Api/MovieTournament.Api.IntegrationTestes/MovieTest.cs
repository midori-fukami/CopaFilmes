using Microsoft.AspNetCore.Mvc.Testing;
using MovieTournament.Api.Models;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieTournament.Api.IntegrationTestes
{
    public class MovieTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        //[OneTimeSetUp]
        public MovieTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllIsSuccessful()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/movie");

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var movies = await response.Content.ReadAsAsync<IEnumerable<Movie>>();

            Assert.Equal(16, movies.Count());
        }
    }
}
