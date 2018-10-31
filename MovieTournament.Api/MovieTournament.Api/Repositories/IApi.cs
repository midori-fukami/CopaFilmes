using MovieTournament.Api.Repositories.Models;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTournament.Api.Repositories
{
    [AllowAnyStatusCode]
    public interface IApi
    {
        [Get("filmes")]
        Task<Response<IEnumerable<MovieModel>>> GetMoviesList();
    }
}
