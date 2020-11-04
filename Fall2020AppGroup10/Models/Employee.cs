using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class Employee : ApplicationUser
    {
        public int HoursWorked { get; set; }

        public Employee(string firstName, string lastName, string address, string phoneNumber, string email, string password, int hoursWorked) :
            base(firstName, lastName, address, phoneNumber, email, password)
        {
            this.HoursWorked = hoursWorked;
        }
        public Employee() { }
    }
}
