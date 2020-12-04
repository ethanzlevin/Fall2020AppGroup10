using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Bet
    {
        [Key]
        public int BetID { get; set; }

        [Required]
        public decimal AmountPlaced { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal? Payout { get; set; } // the amount won or lost only populated after bet clears
        [Column(TypeName = "decimal(18,2)")]

        public short Odds { get; set; } // its a short so we can have negative odds

        [NotMapped]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? Result { get; set; }

        [Required]
        public string BetType { get; set; } //Game or Player

        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]

        //OOC 
        public User User { get; set; }

        public int? PlayerGameID { get; set; }
        [ForeignKey("PlayerGameID")]

        public PlayerGame PlayerGame { get; set; }

        public int? GameID { get; set; }
        [ForeignKey("GameID")]

        public Game Game { get; set; }


        public Bet(decimal amountPlaced, DateTime startDate, DateTime? endDate, bool? result, string userID, short odds, string betType, int? playerGameID, int? gameID)
        {
            this.AmountPlaced = amountPlaced;
            this.Payout = null; //this can be 0 or negative if wrong, and can be signigicantly higher than amount put in
            this.StartDate = startDate;
            this.EndDate = null;
            this.Result = null;
            this.UserID = userID;
            this.Odds = odds;
            this.BetType = betType;
            if (betType == "Player")
            {
                this.PlayerGameID = playerGameID;
            }
            else { this.PlayerGameID = null; }
            if (betType == "Game")
            {
                this.GameID = gameID;
            }
            else { this.GameID = null; }

            
        }

        public Bet() { }


    }
}
