using MovieTournament.Api.Businesses;
using MovieTournament.Api.Models;
using MovieTournament.Api.Test.Data;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTournament.Api.Test.Business
{
    public class MovieBusinessTest
    {
        private readonly MovieBusiness _business;

        public MovieBusinessTest()
        {
            var apiData = new ApiTest();
            _business = new MovieBusiness(apiData);
        }

        [Test]
        public async Task GetMoviesIsSuccessfullAsync()
        {
            var movies = await _business.GetAllAsync();
            Assert.AreEqual(TestData.AllMovies().Count(), movies.Count());
        }

        [Test]
        public void GetWinnerByScoreIsSuccessfull()
        {
            var movie1 = new Movie
            {
                Title = "Os Incríveis 2",
                Score = 8.5
            };

            var movei2 = new Movie
            {
                Title = "Jurassic World: Reino Ameaçado",
                Score = 6.7
            };

            var winner = _business.CompareMovie(movie1, movei2);
            Assert.IsTrue(movie1 == winner);
        }

        [Test]
        public void GetWinnerByTitleIsSuccessfull()
        {
            var movie1 = new Movie
            {
                Title = "Os Incríveis 2",
                Score = 10
            };

            var movie2 = new Movie
            {
                Title = "Jurassic World: Reino Ameaçado",
                Score = 10
            };

            var winner = _business.CompareMovie(movie1, movie2);
            Assert.IsTrue(movie2 == winner);
        }

        [Test]
        public void GetTournamentWinnersIsSuccessfull()
        {
            var win1 = new Movie
            {
                Id = "tt4154756",
                Title = "Vingadores: Guerra Infinita",
                Score = 8.8,
                Year = 2018
            };
            var win2 = new Movie
            {
                Id = "tt3606756",
                Title = "Os Incríveis 2",
                Score = 8.5,
                Year = 2018
            };

            var movies = TestData.SelectedMovies();
            var winners = _business.RunTournament(movies.OrderBy(o => o.Title));

            Assert.AreEqual(winners.ElementAt(0).Id, win1.Id);
            Assert.AreEqual(winners.ElementAt(1).Id, win2.Id);
        }
    }
}
