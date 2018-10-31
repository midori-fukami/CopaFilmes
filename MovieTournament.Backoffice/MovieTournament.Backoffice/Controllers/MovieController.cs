using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieTournament.Backoffice.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Fase de Seleção";
            ViewData["SubTitle"] = "Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.";

            return View();
        }
    }
}