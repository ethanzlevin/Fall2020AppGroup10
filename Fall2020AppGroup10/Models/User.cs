using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class User : ApplicationUser
    {
        //there will be a list here from Bet
        public List<Bet> UserBets {get; set; }

        public List<Payment> UserPayment { get; set; }

        public User(string firstName, string lastName, string address, string phoneNumber, string email, string password) :
            base(firstName, lastName, address, phoneNumber, email, password)
        {
            this.UserBets = new List<Bet>();
            this.UserPayment = new List<Payment>();
        }

        public User() { }
    }
}
