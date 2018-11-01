using Microsoft.AspNetCore.Mvc;
using MovieTournament.Backoffice.Api;
using MovieTournament.Backoffice.Models.Movie;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MovieTournament.Backoffice.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieApi _api;

        public MovieController(IMovieApi api)
        {
            _api = api;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Fase de Seleção";
            ViewData["SubTitle"] = "Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.";

            return View();
        }

        public async Task<ApiResponse<IEnumerable<MovieViewModel>>> GetMovies()
        {
            var result = new ApiResponse<IEnumerable<MovieViewModel>>();
            try
            {
                using (var proxy = await _api.GetMovies())
                {
                    switch (proxy.ResponseMessage.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var movies = proxy.GetContent();
                            result.Data = movies;
                            return result;
                        default:
                            result.Error = new ApiError("1.100", ApiError.ErrorMessage);
                            return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = new ApiError("1.101", ApiError.ErrorMessage);
            }

            return result;
        }

        public IActionResult Winners()
        {
            ViewData["Title"] = "Resultado Final";
            ViewData["SubTitle"] = "Veja o resultado final do Campeonato de filmes de forma simples e rápida.";
            return View();
        }

        public async Task<ApiResponse<IEnumerable<MovieViewModel>>> Tournament(string[] ids)
        {
            var result = new ApiResponse<IEnumerable<MovieViewModel>>();
            try
            {
                using (var proxy = await _api.GetWinners(ids))
                {
                    switch (proxy.ResponseMessage.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var movies = proxy.GetContent();
                            result.Data = movies;
                            return result;
                        default:
                            result.Error = new ApiError("2.100", ApiError.ErrorMessage);
                            return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = new ApiError("2.101", ApiError.ErrorMessage);
            }

            return result;
        }
    }
}