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

        [Required (ErrorMessage ="Must Give a valid dollar amount")]
        [Column(TypeName = "decimal(18,2)")]

        public decimal AmountPlaced { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal? Payout { get; set; } // the amount won or lost only populated after bet clears

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

        
      


        public Bet(decimal amountPlaced, DateTime? endDate, bool? result, string userID, short odds, string betType)
        {
            this.AmountPlaced = amountPlaced;
            this.Payout = null; //this can be 0 or negative if wrong, and can be signigicantly higher than amount put in
            this.StartDate = DateTime.Today.Date;
            this.EndDate = null;
            this.Result = null;
            this.UserID = userID;
            
            this.Odds = odds;
            this.BetType = betType;
            

            
        }

        public Bet() { }


    }
}
