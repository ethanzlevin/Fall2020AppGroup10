using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
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


            //Role service 
            //In startup.cs need to add  .AddRoleManager<IdentityRole>()
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //Creating Users
            //In startup.cs change line 34 identityUser to ApplicationUser
            //In _LoginPartial.cshtml change the IdentityUSer to ApplicaitonUser in line 3 and 4
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string userRole = "User";
            string employeeRole = "Employee";
            

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(userRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(employeeRole);
                roleManager.CreateAsync(role).Wait();
            }

            if (!database.ApplicationUser.Any())
            {
                User user = new User("Test", "Client1", "1 Client1 Address", "3040000001", "TestClient1@test.com", "TestClient1");
                userManager.CreateAsync(user).Wait();
                userManager.AddToRoleAsync(user, userRole).Wait();   //all async method need to have wait() attached

                user = new User("Test", "Client2", "2 Client2 Address", "3040000002", "TestClient2@test.com", "TestClient2");
                userManager.CreateAsync(user).Wait();
                userManager.AddToRoleAsync(user, userRole).Wait();

                Employee employee = new Employee("Test", "Volunteer1", "1 Volunteer1 Address", "3040000003", "Testvolunteer1@test.com", "TestVolunteer1", 43);
                userManager.CreateAsync(employee).Wait();
                userManager.AddToRoleAsync(employee, employeeRole).Wait();

                employee = new Employee("Test", "Volunteer2", "2 Volunteer2 Address", "3040000004", "Testvolunteer2@test.com", "TestVolunteer2", 19);
                userManager.CreateAsync(employee).Wait();
                userManager.AddToRoleAsync(employee, employeeRole).Wait();


            }



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
                //7
                team = new Team("Hawks", "Atlanta", "East", 10, 3);
                database.Team.Add(team);
                database.SaveChanges();
                //8
                team = new Team("Celtics", "Boston", "East", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();
                //9
                team = new Team("Nets", "Brooklyn", "East", 9, 4);
                database.Team.Add(team);
                database.SaveChanges();
                //10
                team = new Team("Hornets", "Charlotte", "East", 0, 13);
                database.Team.Add(team);
                database.SaveChanges();
                //11
                team = new Team("Cavaliers", "Cleveland", "East", 1, 12);
                database.Team.Add(team);
                database.SaveChanges();
                //12
                team = new Team("Mavericks", "Dallas", "West", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();

                //13
                team = new Team("Nuggets", "Denver", "West", 10, 3);
                database.Team.Add(team);
                database.SaveChanges();

                //14
                team = new Team("Pistons", "Detroit", "East", 2, 11);
                database.Team.Add(team);
                database.SaveChanges();
                //15
                team = new Team("Warriors", "Golden State", "West", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();
                //16
                team = new Team("Rockets", "Houston", "West", 10, 3);
                database.Team.Add(team);
                database.SaveChanges();

                //17
                team = new Team("Grizzlies", "Memphis", "West", 9, 4);
                database.Team.Add(team);
                database.SaveChanges();
                //18
                team = new Team("Pacers", "Indiana", "East", 10, 3);
                database.Team.Add(team);
                database.SaveChanges();
                //19
                team = new Team("Heat", "Miami", "East", 12, 1);
                database.Team.Add(team);
                database.SaveChanges();
                //20
                team = new Team("Bucks", "Milwaukee", "West", 10, 3);
                database.Team.Add(team);
                database.SaveChanges();
                //21
                team = new Team("Timberwolves", "Minnesota", "West", 6, 6);
                database.Team.Add(team);
                database.SaveChanges();
                //22
                team = new Team("Pelicans", "New Orleans", "West", 7, 5);
                database.Team.Add(team);
                database.SaveChanges();
                //23
                team = new Team("Knicks", "New York", "East", 0, 13);
                database.Team.Add(team);
                database.SaveChanges();
                //24
                team = new Team("Thunder", "Oklahoma City", "West", 5, 7);
                database.Team.Add(team);
                database.SaveChanges();
                //25
                team = new Team("Magic", "Orlando", "East", 2, 11);
                database.Team.Add(team);
                database.SaveChanges();
                //26
                team = new Team("76ers", "Philadelphia", "East", 13, 0);
                database.Team.Add(team);
                database.SaveChanges();
                //27
                team = new Team("Suns", "Phoenix", "West", 6, 7);
                database.Team.Add(team);
                database.SaveChanges();
                //28
                team = new Team("Trail Blazers", "Portland", "West", 8, 5);
                database.Team.Add(team);
                database.SaveChanges();
                //29
                team = new Team("Kings", "Sacramento", "West", 4, 9);
                database.Team.Add(team);
                database.SaveChanges();
                //30
                team = new Team("Jazz", "Utah", "West", 10, 3);
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

                player = new Player(1, "Rajon", "Rondo", dateOfBrith, "PG", 2006, 2.56m, 10.2m, 8.3m, 45.8m);
                database.Player.Add(player);
                database.SaveChanges();

                dateOfBrith = new DateTime(1986, 2, 22);

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

            if (!database.PlayerGame.Any())
            {
                DateTime GameTime = new DateTime(2020, 10, 13);

                PlayerGame playerGame = new PlayerGame(1, GameTime, 34, 4, 3, 5, 9);
                database.PlayerGame.Add(playerGame);
                database.SaveChanges();


            }
        }

            
    }
}
