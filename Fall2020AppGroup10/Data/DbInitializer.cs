using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();
            
       
            if (!database.Team.Any())
            {
                Team team = new Team("Lakers", "LA", "West", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();

                team = new Team("Clippers", "LA", "West", 5, 8);
                database.Team.Add(team);
                database.SaveChanges();

                team = new Team("Bulls", "Chicago", "East", 2, 11);
                database.Team.Add(team);
                database.SaveChanges();

            }

            
            DateTime dateOfBrith = new DateTime(1984, 12, 30);
            decimal salary = 37.2m;
            decimal pointspergame = 25.3m;
            decimal assistspergame = 10.2m;
            decimal feildgoalpercent = 54.8m;

            if (!database.Player.Any())
            {
                Player player = new Player(1, "Lebron", "James", dateOfBrith, "F", 2003, salary, pointspergame, assistspergame, feildgoalpercent);
                database.Player.Add(player);
                database.SaveChanges();



            }

            
        }
            
    }
}
