using Fall2020AppGroup10.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {
        private ApplicationDbContext database;


       
        public ApplicationUserRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public string FindUserID()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            string userID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userID;
        }//end FindUserID

        public ApplicationUser FindApplicationUser(string userID)
        {
            ApplicationUser applicationUser = database.ApplicationUser.Find(userID);

            return applicationUser;
        }

        public string GetAvailableRoles(string Id)
        {
            string jsonData = null;

            var availableRoleList =
                 //not in 
                 from R in database.Roles
                 where !
                 (
                 //in 
                 from UR in database.UserRoles
                 where UR.UserId == Id
                 select UR.RoleId
                 )
                 .Contains(R.Id)
                 select new { R.Id, R.Name };

            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(availableRoleList);

            return jsonData;
        }

        //Json
        public string GetCurrentRoles(string Id)
        {
            string jsonData = null;
            //LINQ -> SQL sql in c# //select from (join) where
            var userRoleList =
                from UR in database.UserRoles
                join R in database.Roles
                on UR.RoleId equals R.Id
                where UR.UserId == Id
                select new { R.Id, R.Name };

            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleList);

            return jsonData;
        }

        public List<ApplicationUser> ListAllApplicationUsers()
        {
            List<ApplicationUser> applicationUsers = database.ApplicationUser.ToList<ApplicationUser>();

            return applicationUsers;

        }
    }
}
