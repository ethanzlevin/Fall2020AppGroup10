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
            ViewData["AllUsers"] = new SelectList(iBetRepo.ListAllUsers(), "Id", "FullName"); /*list of items, value, text*/

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

            gameBet.StartDate = DateTime.Now.Date;
            gameBet.Odds = 100;

            if (ModelState.IsValid)
            {
                iBetRepo.AddGameBet(gameBet);
                return RedirectToAction("ListAllBetsByUser");
            }
            else
            {
                ViewData["UserID"] = iApplicationUserRepo.FindUserID();


                ViewData["AllGames"] = new SelectList(iBetRepo.GameDropDown(), "GameID", "GameName"); //ask if i can get home vs away using viewbag

                return View();
            }

        }

        [HttpGet]
        public IActionResult AddGameBet()
        {


            ViewData["UserID"] = iApplicationUserRepo.FindUserID();

            ViewData["AllGames"] = new SelectList(iBetRepo.GameDropDown(), "GameID", "GameName");

            return View();
        }



        [HttpGet]
        public void AddPlayerBetOne()
        {
            ViewData["AllGames"] = new SelectList(iBetRepo.GameDropDown(), "GameID", "GameName");

        }
        [HttpPost]
        public IActionResult AddPlayerBetOne(GameSelectViewModel gameSelectViewModel)
        { 
         return RedirectToAction("AddPlayerBet", new {gameID = gameSelectViewModel.GameID }); //maybe?
        }


        [HttpGet]
        public IActionResult AddPlayerBet(int gameID) //meet with someone about this
        {

            ViewData["UserID"] = iApplicationUserRepo.FindUserID();
            ViewData["AllGames"] = new SelectList(iBetRepo.GameDropDown(), "GameID", "GameName");
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayerBet(PlayerBet playerBet)
        {

            playerBet.Odds = 100; //create a calculate odds method

            if (ModelState.IsValid)
            {
                iBetRepo.AddPlayerBet(playerBet);
                return RedirectToAction("ListAllBetsByUser");
            }
            else
            {

                ViewData["UserID"] = iApplicationUserRepo.FindUserID();
                ViewData["AllGames"] = new SelectList(iBetRepo.GameDropDown(), "GameID", "GameName");

                //create a list all players by team

                return View();
            }

        }

        public IActionResult ListAllBetsByUser()
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            allBets = allBets.Where(b => b.UserID == iApplicationUserRepo.FindUserID()).ToList();
            

            return View(allBets);
        }

    }
}