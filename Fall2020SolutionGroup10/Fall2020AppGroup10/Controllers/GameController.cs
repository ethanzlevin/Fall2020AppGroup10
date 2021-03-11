using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Controllers
{
    public class GameController : Controller
    {
        private ITeamRepo iTeamRepo;
        private IGameRepo iGameRepo;

        public GameController(IGameRepo gameRepo, ITeamRepo teamRepo)
        {
            this.iGameRepo = gameRepo;
            this.iTeamRepo = teamRepo;
        }

        //[Authorize(Roles = "Employee, User")]
        public IActionResult ListAllGames()
        {
            List<Game> allGames = iGameRepo.ListAllGames();

            return View(allGames);
        }


        public IActionResult SearchForGameUserInput()
        {
            ViewData["AllTeams"] = new SelectList(iGameRepo.ListAllTeams(), "HomeID", "Name");

            SearchForGamesViewModel searchForGamesViewModel = new SearchForGamesViewModel();

            return View(searchForGamesViewModel);

        }



        public IActionResult SearchForGames(int? homeID, int? awayID, DateTime? startDate, DateTime? endDate)
        {
            List<Game> searchList = iGameRepo.ListAllGames();

           

            if (homeID.HasValue)
            {
                searchList = searchList.Where(g => g.HomeID == homeID).ToList();
            }

            if (awayID.HasValue)
            {
                searchList = searchList.Where(g => g.AwayID == awayID).ToList();
            }

            if (startDate.HasValue)
            {
                searchList = searchList.Where(g => g.Date >= startDate.Value.Date).ToList();
            }

            if (endDate.HasValue)
            {
                searchList = searchList.Where(g => g.Date <= endDate.Value.Date).ToList();
            }

            return View(searchList);

        }

        [HttpGet]//User gets the view
        public IActionResult AddGame()
        {
            ViewData["AllTeams"] = new SelectList(iTeamRepo.ListAllTeams(), "TeamID", "Name");
            return View();
        }

        [HttpPost]//User input sent to server for processing
        public IActionResult AddGame(Game game)
        {
            if (ModelState.IsValid)
            {
                iGameRepo.AddGame(game);
                return RedirectToAction("ListAllGames");
            }
            else
            {
                ViewData["AllTeams"] = new SelectList(iTeamRepo.ListAllTeams(), "TeamID", "Name");
                return View();
            }
        }





    }
}