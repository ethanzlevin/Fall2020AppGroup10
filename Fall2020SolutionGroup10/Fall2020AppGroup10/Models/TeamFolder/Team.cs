using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        
        [Required (ErrorMessage = "Team must be an NBA team")]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required (ErrorMessage = "Division must be East or West")]
        public string Division { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Losses { get; set; }

        public List<Player> PlayersOnTeam { get; set; }

        public List<Game> Game { get; set; }

        public Team() { }

        public Team(string name, string city, string division, int wins, int losses)
        {
            this.Name = name;
            this.City = city;
            this.Division = division;
            this.Wins = wins;
            this.Losses = losses;
            this.PlayersOnTeam = new List<Player>();
            this.Game = new List<Game>();
        }
    }
}
