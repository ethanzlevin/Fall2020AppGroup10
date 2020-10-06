using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; } 
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Position { get; set; }

        //this is not needed to be known for the bets to be made so they are not required but are able to be entered 
        public int RookieYear { get; set; }//it is int becasue we only want the year, the datetime is to specific and is not needed
        public decimal Salary { get; set; }

        //Statistics for the player
        [Required]
        public decimal PointsPerGame { get; set; }
        [Required]
        public decimal AssistsPerGame { get; set; }
        [Required]
        public decimal FieldGoalPercent { get; set; }
        
         
        public Player() { }

        public Player(int playerID, string firstName, string lastName, DateTime dob, string position, int rookieYear, decimal salary, decimal pointsPerGame, decimal assistsPerGame, decimal fieldGoalPercent)
        {
            this.PlayerID = playerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DOB = dob;
            this.Position = position;
            this.RookieYear = rookieYear;
            this.Salary = salary;
            this.PointsPerGame = pointsPerGame;
            this.AssistsPerGame = assistsPerGame;
            this.FieldGoalPercent = fieldGoalPercent;
        }
    }
}
