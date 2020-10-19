using System;
using System.Collections.Generic;
using System.Text;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fall2020AppGroup10.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Team> Team {get; set; }

        public DbSet<Player> Player {get; set; } 

        public DbSet<PlayerGame> PlayerGame { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //internal void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
