using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fall2020AppGroup10.Controllers
{
    public class AppUserController : Controller
    {
        private IApplicationUserRepo iApplicationUserRepo;
        private UserManager<ApplicationUser> userManager;

        public AppUserController(IApplicationUserRepo applicationUserRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.iApplicationUserRepo = applicationUserRepo;
            this.userManager = userManager;
        }
        // 
        [HttpGet]
        public IActionResult AssignAppUserRoles()
        {
            ViewData["AppUsers"] = new SelectList
                (iApplicationUserRepo.ListAllApplicationUsers(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult AssignAppUserRoles(string submitButton, string ddlAppUsers,
            List<string> currentRoles, List<string> availableRoles)
        {
            string userID = ddlAppUsers;
            ApplicationUser applicationUser = iApplicationUserRepo.FindApplicationUser(userID);

            if (submitButton == "AddRolesToUser")
            {
                userManager.AddToRolesAsync(applicationUser, availableRoles).Wait();


            }
            if (submitButton == "RemoveRolesFromUser")
            {
                userManager.RemoveFromRolesAsync(applicationUser, currentRoles).Wait();


            }


            ViewData["AppUsers"] = new SelectList
                (iApplicationUserRepo.ListAllApplicationUsers(), "Id", "FullName", userID);
            return View();
        }
        //^

        //JSON data
        public string GetCurrentRoles(string Id)
        {
            string currentUserRoles = iApplicationUserRepo.GetCurrentRoles(Id);
            return currentUserRoles;
        }
        public string GetAvailableRoles(string Id)
        {
            return iApplicationUserRepo.GetAvailableRoles(Id);
        }

    }
}
