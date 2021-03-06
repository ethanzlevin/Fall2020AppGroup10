using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface IGameRepo
    {
        List<Game> ListAllGames();

        void AddGame(Game game);

        List<Team> ListAllTeams();
    }
}
