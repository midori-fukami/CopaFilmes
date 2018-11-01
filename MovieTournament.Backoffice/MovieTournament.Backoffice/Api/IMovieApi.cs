using Microsoft.AspNetCore.Mvc;
using MovieTournament.Backoffice.Models.Movie;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTournament.Backoffice.Api
{
    [AllowAnyStatusCode]
    public interface IMovieApi
    {
        [Get("Movie")]
        Task<Response<List<MovieViewModel>>> GetMovies();

        [Get("Movie/tournament")]
        Task<Response<List<MovieViewModel>>> GetWinners([FromQuery] string[] ids);        
    }
}
