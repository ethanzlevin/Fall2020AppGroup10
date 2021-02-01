using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fall2020AppGroup10.Controllers
{
    public class TeamController : Controller
    {

        private ITeamRepo iTeamRepo;

        //private ApplicationDbContext database;

        public TeamController(ITeamRepo teamRepo) //ApplicationDbContext dbContext)
        {
            this.iTeamRepo = teamRepo;
            //this.database = dbContext; 
        }

        [Authorize(Roles = "User, Employee")]
        public IActionResult ListAllTeams()
        {
            //List<Team> allTeams = database.Team.ToList();
            List<Team> allTeams = iTeamRepo.ListAllTeams();


            return View(allTeams);
        }

        public IActionResult SearchForTeams(SearchForTeamsViewModel viewModel)
        {
            List<Team> searchList = iTeamRepo.ListAllTeams();

            if(!string.IsNullOrEmpty(viewModel.Name))
            {
                searchList = searchList.Where(p => p.Name == viewModel.Name).ToList();
            }

            if (!string.IsNullOrEmpty(viewModel.City))
            {
                searchList = searchList.Where(p => p.City == viewModel.City).ToList();
            }

            if (!string.IsNullOrEmpty(viewModel.Division))
            {
                searchList = searchList.Where(p => p.Division == viewModel.Division).ToList();
            }

            if (viewModel.MinWins != null)
            {
                searchList = searchList.Where(p => p.Wins >= viewModel.MinWins).ToList();
            }
            if (viewModel.MaxWins != null)
            {
                searchList = searchList.Where(p => p.Wins <= viewModel.MaxWins).ToList();
            }



            if (viewModel.MinLosses != null)
            {
                searchList = searchList.Where(p => p.Losses >= viewModel.MinLosses).ToList();
            }
            if (viewModel.MaxLosses != null)
            {
                searchList = searchList.Where(p => p.Losses <= viewModel.MaxLosses).ToList();
            }

            viewModel.ResultTeamList = searchList;
            return View(viewModel);
        }
        
    }
}
