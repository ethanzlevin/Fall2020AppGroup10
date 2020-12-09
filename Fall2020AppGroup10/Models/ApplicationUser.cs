using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        public string FullName
        {
            get
            { return (FirstName + " " + LastName); }
        }

        public ApplicationUser(string firstName, string lastName, string address, string phoneNumber, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.UserName = email;
            this.PasswordHash = password;
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            passwordHasher.HashPassword(this, password);
            this.SecurityStamp = Guid.NewGuid().ToString();
        }

        public ApplicationUser() { }

    }
}
