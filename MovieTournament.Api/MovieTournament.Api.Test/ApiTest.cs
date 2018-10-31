using MovieTournament.Api.Repositories;
using MovieTournament.Api.Repositories.Models;
using MovieTournament.Api.Test.Data;
using NUnit.Framework;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieTournament.Api.Test
{
    public class ApiTest : IApi
    {
        [Test]
        public void GetMovies()
        {
            Assert.DoesNotThrow(() => TestData.AllMovies());
        }

        [Test]
        public void GetSelectedMovies()
        {
            Assert.DoesNotThrow(() => TestData.SelectedMovies());
        }

        public Task<Response<IEnumerable<MovieModel>>> GetMoviesList()
        {
            var movies = TestData.AllMoviesModel();
            Func<List<MovieModel>> func = new Func<List<MovieModel>>(() => { return movies; });            
            var response = new Response<IEnumerable<MovieModel>>("", new HttpResponseMessage(HttpStatusCode.OK),
                func);

            return Task.Run(() => response);
        }
    }
}
