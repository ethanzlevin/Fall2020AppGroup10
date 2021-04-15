using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface IApplicationUserRepo
    {

        public string FindUserID();


        ApplicationUser FindApplicationUser(string userID);

        List<ApplicationUser> ListAllApplicationUsers();
        string GetCurrentRoles(string Id);
        string GetAvailableRoles(string Id);
    }
}
