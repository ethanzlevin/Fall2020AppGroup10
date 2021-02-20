using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface IBetRepo
    {
        List<Bet> ListAllBets();

        List<User> ListAllUsers();
        void AddBet(PlayerBet playerBet);
        
        void AddBet(GameBet gameBet);
    }
}
