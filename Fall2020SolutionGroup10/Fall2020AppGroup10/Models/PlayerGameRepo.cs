using Fall2020AppGroup10.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class PlayerGameRepo : IPlayerGameRepo
    {
        private ApplicationDbContext database;

        public PlayerGameRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public List<PlayerGameDropDownViewModel> ListAllPlayerinGame(int gameID)
        {
            var dDData =
                from G in database.Game
                join Pg in database.PlayerGame
                on G.GameID equals Pg.GameID
                join P in database.Player on
                Pg.PlayerID equals P.PlayerID

                select new PlayerGameDropDownViewModel
                {
                    GameID = G.GameID,
                    PlayerName = P.FullName,
                    PlayerGameID = Pg.PlayerGameID

                };
            List<PlayerGameDropDownViewModel> playerList = dDData.ToList();

            playerList = playerList.Where(p => p.GameID == gameID).ToList();

            return playerList;
        }
    }
}
