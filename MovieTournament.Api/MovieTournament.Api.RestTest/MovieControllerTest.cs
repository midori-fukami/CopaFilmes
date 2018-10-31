using MovieTournament.Api.Repositories;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace MovieTournament.Api.RestTest
{
    public class MovieControllerTest
    {
        private readonly IApi _api;

        public MovieControllerTest(IApi api)
        {
            _api = api;
        }

        [Test]
        public async Task GetWinnersIsFailure()
        {
            try
            {
                var response = await _api.GetMoviesList();

                Assert.AreEqual(HttpStatusCode.OK, response.ResponseMessage.StatusCode);
            }catch(System.Exception ex)
            {

            }
        }
    }
}
