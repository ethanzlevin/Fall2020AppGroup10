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
        [Required(ErrorMessage = "Please choose a winning team")]
        public string WinningTeam { get; set; } // only set as home or away 

        [Required(ErrorMessage = "Please select a Game")]
        public int? GameID { get; set; }
        [ForeignKey("GameID")]

        public Game Game { get; set; }




        public GameBet(decimal amountPlaced, DateTime? endDate, bool? result, string userID, short odds, string winningTeam, int gameID) :
            base(amountPlaced, endDate, result, userID, odds, "Game")
        {
            this.WinningTeam = winningTeam;
            this.GameID = gameID;
            
        }

        public GameBet() { }

    }
}
