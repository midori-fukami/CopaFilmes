using MovieTournament.Api.Models;
using MovieTournament.Api.Repositories.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieTournament.Api.Test.Data
{
    public static class TestData
    {
        public static IEnumerable<Movie> AllMovies()
        {
            var movies = JsonConvert.DeserializeObject<List<MovieModel>>(File.ReadAllText(@"..\..\..\movies.json"));
            return movies.Select(o => new Movie
            {
                Id = o.Id,
                Year = o.Year,
                Title = o.Title,
                Score = o.Score
            }).ToList();
        }

        public static List<MovieModel> AllMoviesModel()
        {
            return JsonConvert.DeserializeObject<List<MovieModel>>(File.ReadAllText(@"..\..\..\movies.json"));
        }

        public static List<Movie> SelectedMovies()
        {
            var movies = JsonConvert.DeserializeObject<List<MovieModel>>(File.ReadAllText(@"..\..\..\selectedmovies.json"));
            return movies.Select(o => new Movie
            {
                Id = o.Id,
                Year = o.Year,
                Title = o.Title,
                Score = o.Score
            }).ToList();
        }
    }
}
