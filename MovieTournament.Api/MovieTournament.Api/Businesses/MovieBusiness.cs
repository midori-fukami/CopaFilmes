using MovieTournament.Api.Models;
using MovieTournament.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieTournament.Api.Businesses
{
    public class MovieBusiness
    {
        private readonly IApi _api;

        public MovieBusiness(IApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await GetfromApi();
        }

        public async Task<IEnumerable<Movie>> GetWinnersAsync(string[] ids)
        {
            var movies = await GetfromApi();

            if(movies == null) throw new System.Exception("Movie api is down.");

            var moviesApiId = movies.Select(o => o.Id);
            if (!ids.Any(o => moviesApiId.Contains(o)))
                throw new System.Exception("Invalid ids.");

            // order movies
            movies = movies.Where(o => ids.Contains(o.Id)).OrderBy(o => o.Title);

            return RunTournament(movies);
        }

        public async Task<IEnumerable<Movie>> GetfromApi()
        {
            using (var proxy = await _api.GetMoviesList())
            {
                switch (proxy.ResponseMessage.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var movies = proxy.GetContent();
                        return movies.Select(o => new Movie
                        {
                            Id = o.Id,
                            Year = o.Year,
                            Title = o.Title,
                            Score = o.Score
                        });
                    default:
                        return null;
                }
            }
        }

        public IEnumerable<Movie> RunTournament(IEnumerable<Movie> movies)
        {
            var list = new List<Movie>();
            var count = movies.Count();

            // first round
            for (var i = 0; i < count / 2; i++)
            {
                var movie1 = movies.ElementAt(i);
                var movie2 = movies.ElementAt(count - i -1);

                list.Add(CompareMovie(movie1, movie2));
            }

            // after first
            while (list.Count > 1)
            {                
                movies = list;
                count = list.Count();
                list = new List<Movie>();

                for (var i = 0; i < count / 2; i++)
                {
                    var movie1 = movies.ElementAt(i*2);
                    var movie2 = movies.ElementAt(i*2 + 1);

                    list.Add(CompareMovie(movie1, movie2));
                }
            }

            if (list.Count == 1)
            {
                var second = list.ElementAt(0) == movies.ElementAt(0) ? movies.ElementAt(1) : movies.ElementAt(0);
                list.Add(second);
            }
            return list;
        }

        public  Movie CompareMovie(Movie movie1, Movie movie2)
        {
            if (movie1.Score > movie2.Score)
                return movie1;
            else if (movie1.Score < movie2.Score)
                 return movie2;
            else // if (movie1.Score == movie2.Score)
                return string.Compare(movie1.Title, movie2.Title, StringComparison.Ordinal) < 0 ? movie1 : movie2;
        }
    }
}