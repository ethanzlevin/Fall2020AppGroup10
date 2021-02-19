using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class PlayerGame
    {
        [Key]
        public int PlayerGameID { get; set; }

        [Required]
        public DateTime GameDate { get; set; }

        //all of these variables are not required because we wont know them initially 

        public int? Points { get; set; }

        public int? Assists { get; set; }

        public int? Blocks { get; set; }

        public int? Fouls { get; set; }

        public int? Rebounds { get; set; }

        [Required]
        public int PlayerID { get; set; }

        [ForeignKey ("PlayerID")]
        public Player Player { get; set; }
        //can you have a multiple an FK, from an FK on a class previously 

        [Required]
        public int GameID { get; set; }

        [ForeignKey ("GameID")]
        public Game Game { get; set; }


        public List<PlayerBet> PlayerBet { get; set; }



        public PlayerGame(int playerID, DateTime gameDate, int? points, int? assists, int? blocks, int? fouls, int? rebounds, int gameID)
        {
            this.PlayerID = playerID;
            this.GameDate = gameDate;
            this.Points = points;
            this.Assists = assists;
            this.Blocks = blocks;
            this.Fouls = fouls;
            this.Rebounds = rebounds;
            this.GameID = gameID;
            this.PlayerBet = new List<PlayerBet>();
        }

        public PlayerGame() { }
    }
}
