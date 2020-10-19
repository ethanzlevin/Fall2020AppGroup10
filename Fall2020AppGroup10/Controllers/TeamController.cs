using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fall2020AppGroup10.Controllers
{
    public class TeamController : Controller
    {
        private ApplicationDbContext database;

        public TeamController(ApplicationDbContext dbContext)
        {
            this.database = dbContext; 
        }

        public IActionResult ListAllTeams()
        {
            List<Team> allTeams = database.Team.ToList();
            
            return View(allTeams);
        }
    }
}
