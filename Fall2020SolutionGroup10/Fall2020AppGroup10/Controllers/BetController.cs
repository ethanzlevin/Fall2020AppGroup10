﻿using Fall2020AppGroup10.Models;
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
        
        public void AddBet(GameBet gameBet)
        {
            throw new NotImplementedException();
        }

        public void AddBet(PlayerBet playerBet)
        {
            throw new NotImplementedException();
        }
    }
}