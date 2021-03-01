using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        public int TeamID { get; set; }
        
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName
        { get { return (FirstName + " " + LastName); } }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Position { get; set; }

        //this is not needed to be known for the bets to be made so they are not required but are able to be entered 
        [Required]
        public int RookieYear { get; set; }//it is int becasue we only want the year, the datetime is to specific and is not needed
        
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]

        public decimal Salary { get; set; }
        

        //Statistics for the player
        [Required]
        [Column(TypeName = "decimal(18,2)")]

        public decimal PointsPerGame { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]

        public decimal AssistsPerGame { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]

        public decimal FieldGoalPercent { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }

        public List<PlayerGame> PlayerGame { get; set; }

        

        public Player(int teamID, string firstName, string lastName, DateTime dob, string position, int rookieYear, decimal salary, decimal pointsPerGame, decimal assistsPerGame, decimal fieldGoalPercent)
        {
            this.TeamID = teamID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DOB = dob;
            this.Position = position;
            this.RookieYear = rookieYear;
            this.Salary = salary;
            this.PointsPerGame = pointsPerGame;
            this.AssistsPerGame = assistsPerGame;
            this.FieldGoalPercent = fieldGoalPercent;
            this.PlayerGame = new List<PlayerGame>();
        }

        public Player() { }

    }
}
