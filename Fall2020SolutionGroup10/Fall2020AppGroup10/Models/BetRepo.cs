using Fall2020AppGroup10.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class BetRepo : IBetRepo
    {
        private ApplicationDbContext database;

        public BetRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public List<Bet> ListAllBets()
        {
            List<Bet> bets = database.Bet.ToList();
            return bets;
        }


        public List<User> ListAllUsers()
        {
            List<User> user = database.User.ToList();
            return user;
        }

    }
}
