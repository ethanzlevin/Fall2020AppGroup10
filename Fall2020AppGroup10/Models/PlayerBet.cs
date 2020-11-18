using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class PlayerBet
    {
        [Key]
        public int PlayerBetID { get; set; }

        [Required]
        public decimal StrikeValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        [NotMapped]
        public string BetType { get; set; }


        public int PlayerGameID { get; set; }
        [ForeignKey("PlayerGameID")]

        public PlayerGame PlayerGame { get; set; }

        public List<Bet> Bet { get; set; }

        public PlayerBet(decimal strikeValue, string betType, int playerGameID)
        {
            this.StrikeValue = strikeValue;
            this.BetType = betType;
            this.PlayerGameID = playerGameID;
            this.Bet = new List<Bet>();
        }

        public PlayerBet() { }


    }
}
