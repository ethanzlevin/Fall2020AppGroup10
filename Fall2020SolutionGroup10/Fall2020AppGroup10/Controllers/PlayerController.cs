using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fall2020AppGroup10.Controllers
{
    public class PlayerController : Controller
    {
        //private ApplicationDbContext database;
        private IPlayerRepo iPlayerRepo;
        private ITeamRepo iTeamRepo;

        public PlayerController(IPlayerRepo playerRepo, ITeamRepo teamRepo) //ApplicationDbContext dbContext)
        {
            //this.database = dbContext;
            this.iPlayerRepo = playerRepo;
            this.iTeamRepo = teamRepo;
        }

        public void EditPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            ViewData["AllPlayers"] = new SelectList(iPlayerRepo.ListAllPlayers(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(Player player)
        {
            if(ModelState.IsValid)
            {
                iPlayerRepo.AddPlayer(player);
                return RedirectToAction("ListAllPlayers");
            }
            else
            {
                ViewData["AllPlayers"] = new SelectList(iPlayerRepo.ListAllPlayers(), "Id", "FullName");
                return View();
            }
        }

        public IActionResult ListAllPlayers()
        {
            List<Player> allPlayers = iPlayerRepo.ListAllPlayers();
            return View(allPlayers);
        }

        public IActionResult SearchForPlayers(SearchForPlayerViewModel viewModel)
        {
           
            ViewData["AllTeams"] = new SelectList(iTeamRepo.ListAllTeams(), "TeamID", "Name"); /*list of items, value, text*/ //this is where I cannot get the dropdown to populate

            List<Player> searchList;

            if (viewModel.UserFirstVisit != "No")
            {
                searchList = null;
            }
            else
            {
                searchList = iPlayerRepo.ListAllPlayers();

                if (viewModel.TeamID != 0)
                {
                    searchList = searchList.Where(b => b.TeamID == viewModel.TeamID).ToList();
                }
                if (viewModel.Position != null)
                {
                    searchList = searchList.Where(b => b.Position.ToLower().Contains(viewModel.Position.ToLower())).ToList();
                }
                if (viewModel.LastName != null)
                {
                    searchList = searchList.Where(b => b.LastName.ToLower().Contains(viewModel.LastName.ToLower())).ToList();
                }
            }

            viewModel.ResultList = searchList;

            return View(viewModel);
        }

    }
}

