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

        public BetController(IBetRepo betRepo)
        {
            this.iBetRepo = betRepo;
        }

        //[Authorize(Roles = "Employee")]
        public IActionResult ListAllBets()
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            return View(allBets);
        }


        public IActionResult SearchForBetsUserInput()
        {
            //Dynamic drop down list of clients from DB

            ViewData["AllUsers"] = new SelectList(iBetRepo.ListAllUsers(), "UserName", "FullName"); /*list of items, value, text*/ //this is where I cannot get the dropdown to populate

            SearchForBetsViewModel searchForBetsViewModel = new SearchForBetsViewModel();

            return View(searchForBetsViewModel);
        }

        //[Authorize(Roles = "Employee")]
        public IActionResult SearchAllBets(string userID)
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            if (userID != null)
            {
                allBets = allBets.Where(b => b.UserID == userID).ToList();
            }

            return View(allBets);
        }
    }
}