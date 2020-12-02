using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class GameBet : Bet  //game bet is only to bet if a team wins or loses no betting the spread
    {
        [Required]
        public string WinningTeam { get; set; } // only set as home or away 

        
        

        

        public GameBet(decimal amountPlaced, DateTime startDate, DateTime? endDate, bool? result, string userID, short odds, string winningTeam, int gameID) :
            base(amountPlaced, startDate, endDate, result, userID, odds, "Game", null, gameID)
        {
            this.WinningTeam = winningTeam;
            
            
        }

        public GameBet() { }

    }
}
