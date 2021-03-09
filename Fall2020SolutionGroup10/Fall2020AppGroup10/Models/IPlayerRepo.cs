using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface IPlayerRepo
    {
        List<Player> ListAllPlayers();

        void AddPlayer(Player player);

        //void EditPlayer(Player player);
    }
}
