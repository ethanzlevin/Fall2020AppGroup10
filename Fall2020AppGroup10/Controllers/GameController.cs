using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Controllers
{
    public class GameController : Controller
    {

        private IGameRepo iGameRepo;

        public GameController(IGameRepo gameRepo)
        {
            this.iGameRepo = gameRepo;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult ListAllGames()
        {
            List<Game> allGames = iGameRepo.ListAllGames();

            return View(allGames);
        }
    }
}