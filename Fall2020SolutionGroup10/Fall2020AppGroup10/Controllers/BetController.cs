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
    public class BetController : Controller
    {

        private IBetRepo iBetRepo;
        private IApplicationUserRepo iApplicationUserRepo;
        private IGameRepo iGameRepo;

        public BetController(IBetRepo betRepo, IApplicationUserRepo applicationUserRepo, IGameRepo gameRepo)
        {
            this.iBetRepo = betRepo;
            this.iApplicationUserRepo = applicationUserRepo;
            this.iGameRepo = gameRepo;
        }

        //[Authorize(Roles = "Employee")]
        public IActionResult ListAllBets()
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            return View(allBets);
        }


        
        public IActionResult SearchForBets(SearchForBetsViewModel searchForBets)
        {
            ViewData["AllUsers"] = new SelectList(iBetRepo.ListAllUsers(), "Id", "FullName"); /*list of items, value, text*/ //this is where I cannot get the dropdown to populate

            List<Bet> searchList;

            if (searchForBets.FirstVisit != "No")
            { searchList = null; }
            else
            { searchList = iBetRepo.ListAllBets(); }


            if (searchForBets.UserID != null)
            {
                searchList = searchList.Where(b => b.UserID == searchForBets.UserID).ToList();
            }
            searchForBets.BetResultList = searchList;

            return View(searchForBets);
        }
        [HttpPost]
        public IActionResult AddGameBet(GameBet gameBet)
        {
           
            gameBet.UserID = iApplicationUserRepo.FindUserID();
            gameBet.BetType = "Game";
            gameBet.Odds = 100;
            gameBet.StartDate = DateTime.Today.Date;
            if (gameBet.GameID.HasValue && gameBet.WinningTeam.Any())
            {
                iBetRepo.AddGameBet(gameBet);
                return RedirectToAction("ListAllBets");
            }
            else
            {
                ViewData["AllGames"] = new SelectList(iGameRepo.ListAllGames(), "GameID", "HomeID"); //ask if i can get home vs away using viewbag

                return View();
            }

        }
        [HttpPost]
        public IActionResult AddPlayerBet(PlayerBet playerBet)
        {
            playerBet.UserID = iApplicationUserRepo.FindUserID();
            playerBet.Odds = 100; //create a calculate odds method
            playerBet.BetType = "Player";
            if (ModelState.IsValid)
            {
                iBetRepo.AddPlayerBet(playerBet);
                return RedirectToAction("ListAllBetsByUser"); // make a list all bets for user
            }
            else
            {
                ViewData["AllGames"] = new SelectList(iGameRepo.ListAllGames(), "GameID", "HomeID"); //ask if i can get home vs away using viewbag

               //create a list all players by team

                return View();
            }

        }
        
        [HttpGet]
        public IActionResult AddGameBet()
        {
            ViewData["AllGames"] = new SelectList(iGameRepo.ListAllGames(), "GameID", "HomeID"); //ask if i can get home vs away using viewbag
            return View();
        }

        [HttpGet]
        public IActionResult AddPlayerBet()
        {
            ViewData["AllGames"] = new SelectList(iGameRepo.ListAllGames(), "GameID", "HomeID"); //ask if i can get home vs away using viewbag
            return View();
        }

        public IActionResult ListAllBetsByUser()
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            allBets = allBets.Where(b => b.UserID == iApplicationUserRepo.FindUserID()).ToList();
            

            return View(allBets);
        }

    }
}