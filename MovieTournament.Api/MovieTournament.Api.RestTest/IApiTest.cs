using Microsoft.AspNetCore.Mvc;
using MovieTournament.Api.Repositories.Models;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieTournament.Api.RestTest
{
    public interface IApiTest
    {
        [Get()]
        Task<Response<IEnumerable<MovieModel>>> GetMoviesList();

        [Get("tournament")]
        Task<Response<IEnumerable<MovieModel>>> GetWinners([FromQuery] string[] ids);
    }
}
