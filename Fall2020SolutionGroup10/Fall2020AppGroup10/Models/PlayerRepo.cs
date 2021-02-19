using Fall2020AppGroup10.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class PlayerRepo : IPlayerRepo
    {
        private ApplicationDbContext database;

        public PlayerRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public void AddPlayer(Player player)
        {
            database.Player.Add(player);
            database.SaveChanges();
        }

    }
}
