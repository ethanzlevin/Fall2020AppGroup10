using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "teamId")]
        public int TeamID { get; set; }
        
        [Required (ErrorMessage = "Team must be an NBA team")]
        [JsonProperty(PropertyName = "nickname")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        
        [Required (ErrorMessage = "Division must be East or West")]
        [JsonProperty(PropertyName = "confName")]
        public string Division { get; set; }

        
        public int Wins { get; set; }

        
        public int Losses { get; set; }

        public List<Player> PlayersOnTeam { get; set; }

        public List<Game> Game { get; set; }

        public Team() { }

        public Team(string name, string city, string division)
        {
            this.Name = name;
            this.City = city;
            this.Division = division;
            
            this.PlayersOnTeam = new List<Player>();
            this.Game = new List<Game>();
        }
    }
}
