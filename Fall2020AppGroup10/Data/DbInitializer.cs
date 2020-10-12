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
                //1
                Team team = new Team("Lakers", "LA", "West", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();

                //2
                team = new Team("Clippers", "LA", "West", 5, 8);
                database.Team.Add(team);
                database.SaveChanges();

                //3
                team = new Team("Bulls", "Chicago", "East", 2, 11);
                database.Team.Add(team);
                database.SaveChanges();

                //4
                team = new Team("Wizards", "Washington", "East", 2, 11);
                database.Team.Add(team);
                database.SaveChanges();

                //4
                team = new Team("Jazz", "Utah", "East", 7, 6);
                database.Team.Add(team);
                database.SaveChanges();

                //5
                team = new Team("Raptors", "Toronto", "East", 0, 13);
                database.Team.Add(team);
                database.SaveChanges();

                //6
                team = new Team("Spurs", "San Antonio", "West", 13, 0);
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

                dateOfBrith = new DateTime(1991, 6, 29);

                player = new Player(2, "Kawhi", "Leonard", dateOfBrith, "F", 2011, 32.74m, 27.1m, 4.9m, 47m);
                database.Player.Add(player);
                database.SaveChanges();

                dateOfBrith = new DateTime(1990, 5, 2);

                player = new Player(2, "Paul", "George", dateOfBrith, "F", 2010, 33.01m, 21.5m, 3.9m, 43.9m);
                database.Player.Add(player);
                database.SaveChanges();

                dateOfBrith = new DateTime(1989, 8, 7);

                player = new Player(6, "DeMar", "DeRozan", dateOfBrith, "F", 2009, 26.54m, 22.1m, 5.6m, 53.1m);
                database.Player.Add(player);
                database.SaveChanges();

                dateOfBrith = new DateTime(1985, 7, 19);

                player = new Player(6, "LaMarcus", "Aldridge", dateOfBrith, "F", 2006, 19.69m, 18.9m, 2.4m, 49.3m);
                database.Player.Add(player);
                database.SaveChanges();



            }


        }
            
    }
}
