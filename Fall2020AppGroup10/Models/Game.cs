using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool? Favorite { get; set; }

        public int? Score { get; set; }

        [Required]
        public int HomeID { get; set; }
        [ForeignKey("HomeID")]


        [Required]
        public int AwayID { get; set; }
        [ForeignKey("AwayID")]

        public Team Team { get; set; }

        public List<GameBet> GameBet { get; set; }

        public List<PlayerGame> PlayerGame { get; set; }

        public Game(DateTime date, bool? favorite, int? score, int homeID, int awayID) 
        {
            this.Date = date;
            this.Favorite = favorite;
            this.Score = score;
            this.HomeID = homeID;
            this.AwayID = awayID;
            this.GameBet = new List<GameBet>();
            this.PlayerGame = new List<PlayerGame>();
        }

        public Game() { }


    }
}
