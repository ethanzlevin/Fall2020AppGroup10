using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class GameBet
    {
        [Key]
        public int GameBetID { get; set; }

        public decimal? Odds { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public int? HomeScore { get; set; }

        public int? AwayScore { get; set; }

        [Required]
        public int GameID { get; set; }
        [ForeignKey("GameID")]

        public Game Game { get; set; }

        public List<Bet> Bet { get; set; }

        public GameBet(decimal? odds, int? homeScore, int? awayScore, int gameID)
        {
            this.Odds = odds;
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
            this.GameID = gameID;
            this.Bet = new List<Bet>();
        }

        public GameBet() { }

    }
}
