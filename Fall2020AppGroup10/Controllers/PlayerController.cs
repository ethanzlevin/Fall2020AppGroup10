using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fall2020AppGroup10.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext database;

        public PlayerController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public IActionResult ListAllPlayer()
        {
            List<Player> allPlayer = database.Player.ToList();

            return View(allPlayer);
        }
    }
}

