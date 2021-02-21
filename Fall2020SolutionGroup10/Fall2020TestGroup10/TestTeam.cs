//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;
//using Xunit.Abstractions;
//using Fall2020AppGroup10.Controllers;
//using Fall2020AppGroup10.Data;
//using Fall2020AppGroup10.Models;
//using Moq;
//using Microsoft.AspNetCore.Mvc;

//namespace Fall2020TestGroup10
//{    
//    public class TestTeam
//    {
//        private Mock<ITeamRepo> mockTeamRepo;


//        [Fact]
//        public void ShouldListAllTeams()
//        {
//            mockTeamRepo = new Mock<ITeamRepo>();

//            List<Team> mockTeams = CreateMockTeamData();
//            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

//            int expectedNumberOfTeamsInList = 3;

//            TeamController teamController = new TeamController(mockTeamRepo.Object);

//            ViewResult result = teamController.ListAllTeams() as ViewResult;
//            List<Team> resultModel = result.Model as List<Team>;
//            int actualNumberOfTeamsInList = resultModel.Count;

//            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamsInList);

//            //ApplicationDbContext database = null;


//            //TeamController teamController = new TeamController(database);
//            //teamController.ListAllTeams();


//        }

//        public List<Team> CreateMockTeamData()
//        {
//            List<Team> mockTeams = new List<Team>();

//            Team team = new Team("Test Team 1", "LA", "West", 5, 8);
//            mockTeams.Add(team);

//            team = new Team("Test Team 2", "Boston", "East", 10, 3);
//            mockTeams.Add(team);

//            team = new Team("Test Team 3", "LA", "West", 0, 13);
//            mockTeams.Add(team);

//            return mockTeams;
//        }
//    }
//}
