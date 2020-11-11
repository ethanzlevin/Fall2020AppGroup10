using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public decimal StartingDeposit { get; set; }

        [Required]
        public string Type { get; set; }


        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]

        //OOC 
        public User User { get; set; }

        public Payment(decimal balance, decimal startingDeposit, string type, string userID)
        {
            this.Balance = balance;
            this.StartingDeposit = startingDeposit;
            this.Type = type;
            this.UserID = userID;
        }

        public Payment() { }



    }
}
