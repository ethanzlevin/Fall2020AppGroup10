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


        
    }
}
