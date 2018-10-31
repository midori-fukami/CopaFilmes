using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieTournament.Api.Businesses;
using MovieTournament.Api.Models;

namespace MovieTournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(500)]
    public class MovieController : BaseController
    {
        private readonly MovieBusiness _business;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="business"></param>
        public MovieController(MovieBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// Get list of Movies
        /// </summary>
        /// <returns>List of Movies</returns>
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return RunDefaultAsync(async () => Ok(await _business.GetAllAsync()));
        }

        /// <summary>
        /// Get winners
        /// </summary>
        /// <returns>List of winners Movies</returns>
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        [HttpGet("tournament")]
        public Task<IActionResult> GetWinners([FromQuery] string[] ids)
        {
            return RunDefaultAsync(async () => Ok(await _business.GetWinnersAsync(ids)));
        }
    }
}