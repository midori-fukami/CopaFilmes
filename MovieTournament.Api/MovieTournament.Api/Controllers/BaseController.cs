using Microsoft.AspNetCore.Mvc;
using MovieTournament.Api.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MovieTournament.Api.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        public T GetProxy<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        ///     Run <paramref name="predicate" /> under default statement.
        /// </summary>
        /// <param name="predicate">Function to be ran.</param>
        /// <returns><paramref name="predicate" /> return or default return in case of an error has been thrown.</returns>
        protected async Task<IActionResult> RunDefaultAsync(Func<Task<IActionResult>> predicate)
        {
            try
            {
                return await predicate();
            }
            catch (System.Exception exception)
            {
                return StatusCode(500, new ErrorProxy
                {
                    Code = 0,
                    Message = exception.Message
                });
            }
        }
    }
}
