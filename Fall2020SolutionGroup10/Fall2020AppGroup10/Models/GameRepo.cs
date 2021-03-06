using Fall2020AppGroup10.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class GameRepo : IGameRepo
    {
        private ApplicationDbContext database;

        public GameRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public List<Game> ListAllGames()
        {
            List<Game> games = database.Game.ToList();
            return games;
        }

        public List<Team> ListAllTeams()
        {
            List<Team> teams = database.Team.ToList();
            return teams;
        }


        public void AddGame(Game game)
        {
            database.Game.Add(game);
            database.SaveChanges();
        }


    }
}
