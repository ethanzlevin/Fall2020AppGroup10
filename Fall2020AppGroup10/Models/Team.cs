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
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string Division { get; set; }

        public Team() { }

        public Team(int teamID, string name, string city, string division)
        {
            this.TeamID = teamID;
            this.Name = name;
            this.City = city;
            this.Division = division; 
        }
    }
}
