using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class PlayerBet : Bet //player bet is only to bet if a player reaches a specific statistic i.e. 10 rebounds
    {
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StrikeValue { get; set; } // the value user bets for any given statistic
        

        [NotMapped]
        public string BetStat { get; set; } // the statistic the user is betting on


       

        

        public PlayerBet(decimal amountPlaced, DateTime startDate, DateTime? endDate, bool? result, string userID, short odds, decimal strikeValue, string betStat, int playerGameID) :
            base(amountPlaced, startDate, endDate, result, userID, odds, "Player", playerGameID, null)
        {
            this.StrikeValue = strikeValue;
            this.BetStat = betStat;
            
            
        }

        public PlayerBet() { }


    }
}
