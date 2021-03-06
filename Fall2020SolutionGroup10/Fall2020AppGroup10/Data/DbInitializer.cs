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



            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

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
                User user = new User("Test", "User1", "1 User1 Address", "3040000001", "TestUser1@test.com", "TestUser1");
                user.EmailConfirmed = true;
                userManager.CreateAsync(user).Wait();
                userManager.AddToRoleAsync(user, userRole).Wait();   //all async method need to have wait() attached

                user = new User("Test", "User2", "2 User2 Address", "3040000002", "TestUser2@test.com", "TestUser2");
                user.EmailConfirmed = true;
                userManager.CreateAsync(user).Wait();
                userManager.AddToRoleAsync(user, userRole).Wait();

                Employee employee = new Employee("Test", "Employee1", "1 Employee1 Address", "3040000003", "TestEmployee1@test.com", "TestEmployee1", 43);
                employee.EmailConfirmed = true;
                userManager.CreateAsync(employee).Wait();
                userManager.AddToRoleAsync(employee, employeeRole).Wait();

                employee = new Employee("Test", "Employee2", "2 Employee2 Address", "3040000004", "TestEmployee2@test.com", "TestEmployee2", 19);
                employee.EmailConfirmed = true;
                userManager.CreateAsync(employee).Wait();
                userManager.AddToRoleAsync(employee, employeeRole).Wait();
            }
        

            if (!database.Payment.Any())
            {
                User user = database.User.Where(c => c.Email == "TestUser1@test.com").FirstOrDefault();
                string userID = user.Id;

                Payment payment = new Payment(33.01m, 42.1m, "Paypal", userID);
                database.Payment.Add(payment);
                database.SaveChanges();

                payment = new Payment(102.10m, 45.45m, "Venmo", userID);
                database.Payment.Add(payment);
                database.SaveChanges();

                user = database.User.Where(c => c.Email == "TestUser2@test.com").FirstOrDefault();
                userID = user.Id;

                payment = new Payment(1452.89m, 1441.23m, "Venmo", userID);
                database.Payment.Add(payment);
                database.SaveChanges();

            }




            if (!database.Team.Any())
            {
                //1
                Team team = new Team("Lakers", "LA", "West");
                database.Team.Add(team);
                database.SaveChanges();

                //2
                team = new Team("Clippers", "LA", "West");
                database.Team.Add(team);
                database.SaveChanges();

                //3
                team = new Team("Bulls", "Chicago", "East");
                database.Team.Add(team);
                database.SaveChanges();

                //4
                team = new Team("Wizards", "Washington", "East");
                database.Team.Add(team);
                database.SaveChanges();

                //4
                team = new Team("Jazz", "Utah", "East");
                database.Team.Add(team);
                database.SaveChanges();

                //5
                team = new Team("Raptors", "Toronto", "East");
                database.Team.Add(team);
                database.SaveChanges();

                //6
                team = new Team("Spurs", "San Antonio", "West");
                database.Team.Add(team);
                database.SaveChanges();
                //7
                team = new Team("Hawks", "Atlanta", "East");
                database.Team.Add(team);
                database.SaveChanges();
                

            }


            if (!database.Player.Any())
            {

                DateTime dateOfBrith = new DateTime(1984, 12, 30);
                decimal salary = 37.2m;
                decimal pointspergame = 25.3m;
                decimal assistspergame = 10.2m;
                decimal feildgoalpercent = 54.8m;


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

            DateTime GameTime = new DateTime(2020, 10, 13);

            if (!database.Game.Any())
            {

                Game game = new Game(GameTime, true, 35, 1, 2);
                database.Game.Add(game);
                database.SaveChanges();
            }

            if (!database.PlayerGame.Any())
            {
                

                PlayerGame playerGame = new PlayerGame(1, GameTime, 34, 4, 3, 3, 9, 1);
                database.PlayerGame.Add(playerGame);
                database.SaveChanges();


            }






            if (!database.Bet.Any())
            {
                User user = database.User.Where(c => c.Email == "TestUser1@test.com").FirstOrDefault();
                string userID = user.Id;

                DateTime startdate = new DateTime(2020, 11, 9);
                DateTime enddate = new DateTime(2020, 11, 11);

                PlayerBet playerBet = new PlayerBet(15.00m, enddate, null, userID, -120, 10, "Assists", 1);
                database.PlayerBet.Add(playerBet);
                database.SaveChanges();

                user = database.User.Where(c => c.Email == "TestUser2@test.com").FirstOrDefault();
                userID = user.Id;

                GameBet gameBet = new GameBet(10.00m,enddate,null, userID, 200, "Away", 1);
                database.GameBet.Add(gameBet);
                database.SaveChanges();


            }




        }

            
    }
}
