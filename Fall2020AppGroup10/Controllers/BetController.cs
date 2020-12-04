using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "Employee")]
        public IActionResult ListAllBets()
        {
            List<Bet> allBets = iBetRepo.ListAllBets();

            return View(allBets);
        }
    }
}