using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup10.Controllers
{
    public class TeamController : Controller
    {

        private ITeamRepo iTeamRepo;
        private IPlayerRepo iPlayerRepo;

        //private ApplicationDbContext database;

        public TeamController(ITeamRepo teamRepo, IPlayerRepo playerRepo) //ApplicationDbContext dbContext)
        {
            this.iTeamRepo = teamRepo;
            this.iPlayerRepo = playerRepo;
            //this.database = dbContext; 
        }

        public void AddTeam(Team team)
        {
            if(ModelState.IsValid)
            {
                int teamID = iTeamRepo.AddTeam(team);

                string firstName = "FirstName";
                string lastName = "LastName";
                DateTime dob = new DateTime(1984, 12, 30);
                string position = "C";
                int rookieYear = 2005;
                decimal salary = 0.0m;
                decimal pointsPerGame = 0.0m;
                decimal assistsPerGame = 0.0m;
                decimal feildGoalPercent = 0.0m;

                Player player = new Player(teamID, firstName, lastName, dob, position, rookieYear, salary,  pointsPerGame, assistsPerGame, feildGoalPercent);
                iPlayerRepo.AddPlayer(player);
            }
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
            ViewData["AllTeams"] = new SelectList(iTeamRepo.ListAllTeams(), "TeamID", "Name");
            ViewData["AllCities"] = new SelectList(iTeamRepo.ListAllTeams(), "TeamID", "City");

            List<Team> searchList; //= iTeamRepo.ListAllTeams();

            if (viewModel.UserFirstVisit != "No")
            {
                searchList = null;
            }

            else
            {
                searchList = iTeamRepo.ListAllTeams();

                //if (!string.IsNullOrEmpty(viewModel.TeamID))
                if (viewModel.TeamID != null)
                {
                    searchList = searchList.Where(p => p.TeamID == viewModel.TeamID).ToList();
                }

                if (viewModel.TeamID1 != null)
                {
                    searchList = searchList.Where(p => p.TeamID == viewModel.TeamID1).ToList();
                }

                if (!string.IsNullOrEmpty(viewModel.Name))
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
            }

            viewModel.ResultTeamList = searchList;
            return View(viewModel);
        }
        
    }
}
