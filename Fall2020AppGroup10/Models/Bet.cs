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

        public decimal Payout { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        [NotMapped]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Result { get; set; }


        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]

        //OOC 
        public User User { get; set; }

        [Required]
        public int? PlayerBetID { get; set; }
        [ForeignKey("PlayerBetID")]

        public PlayerBet PlayerBet { get; set; }

        public int? GameBetID { get; set; }
        [ForeignKey("GameBetID")]

        public GameBet GameBet { get; set; }

        public Bet(decimal amountPlaced, decimal payout, DateTime startDate, DateTime? endDate, string result, string userID, int? playerBetID, int? gameBetID)
        {
            this.AmountPlaced = amountPlaced;
            this.Payout = payout; //this can be 0 or negative if wrong, and can be signigicantly higher than amount put in
            this.StartDate = startDate;
            this.EndDate = null;
            this.Result = result;
            this.UserID = userID;
            this.PlayerBetID = playerBetID;
            this.GameBetID = gameBetID;
        }

        public Bet() { }


    }
}
