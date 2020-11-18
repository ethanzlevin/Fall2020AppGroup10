using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Data;

namespace Fall2020TestGroup10
{
    
    public class TestTeam
    {
        [Fact(Skip = "Not Implemented")]
        public void ShouldListAllTeams()
        {

            ApplicationDbContext database = null;


            TeamController teamController = new TeamController(database);
            teamController.ListAllTeams();


        }
    }
}
