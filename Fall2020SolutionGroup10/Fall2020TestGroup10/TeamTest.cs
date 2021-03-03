using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Data;
using Fall2020AppGroup10.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fall2020TestGroup10
{
    public class TeamTest
    {
        private Mock<ITeamRepo> mockTeamRepo;
        private Mock<IPlayerRepo> mockPlayerRepo;

        private TeamController teamController;



        public TeamTest()
        {
            mockTeamRepo = new Mock<ITeamRepo>();
            mockPlayerRepo = new Mock<IPlayerRepo>();

            teamController = new TeamController(mockTeamRepo.Object, mockPlayerRepo.Object);
        }

        

        [Fact]
        public void ShouldEditTeam()
        {
            //1. Arrange
            Team team = new Team("Test Name Edit", "Test City Edit", "Test Division Edit", 10, 10);
            team.TeamID = 50;
            mockTeamRepo.Setup(m => m.EditTeam(It.IsAny<Team>()));

            //2. Act
            teamController.EditTeam(team);

            //3. Assert
            mockTeamRepo.Verify(m => m.EditTeam(team), Times.Exactly(1));
        }


        [Fact]
        public void ShouldDeletePet()
        {
            //1. Arrange
            //DateTime dateOfBirth = new DateTime(2021, 1, 1);
            Team team = new Team("Test Team", "Test City", "Test Division", 0, 13);

            team.TeamID = 6;
            mockTeamRepo.Setup(m => m.DeleteTeam(It.IsAny<Team>()));

            //2. Act
            teamController.DeleteTeam(team);

            //3. Assert (Verification)
            mockTeamRepo.Verify(m => m.DeleteTeam(team), Times.Exactly(1));

        }


        [Fact]
        public void ShouldAddNewTeam()
        {
            //1. Arrange 
            Team team = new Team("Test Name", "Test City", "Test Region", 10, 10);
            team.TeamID = 10;

            mockTeamRepo.Setup(t => t.AddTeam(team)).Returns(team.TeamID);

            Player player = null;
            mockPlayerRepo.Setup(p => p.AddPlayer(It.IsAny<Player>())).Callback<Player>(p => player = p);

            //2. Act
            teamController.AddTeam(team);

            //3. Assert (verification)
            mockTeamRepo.Verify(t => t.AddTeam(team), Times.Exactly(1));



            /*   Data From Controller
            string firstName = "FirstName";
            string lastName = "LastName";
            DateTime dob = new DateTime(1984, 12, 30);
            string position = "C";
            int rookieYear = 2005;
            decimal salary = 0.0m;
            decimal pointsPerGame = 0.0m;
            decimal assistsPerGame = 0.0m;
            decimal feildGoalPercent = 0.0m;
            */

            DateTime TestPlayerDOB = new DateTime(1984, 12, 30);

            Assert.Equal("FirstName", player.FirstName);
            Assert.Equal("LastName", player.LastName);
            Assert.Equal(TestPlayerDOB, player.DOB);
            Assert.Equal(2005, player.RookieYear);
            Assert.Equal(0.0m, player.Salary);
            Assert.Equal(0.0m, player.PointsPerGame);
            Assert.Equal(0.0m, player.AssistsPerGame);
            Assert.Equal(0.0m, player.FieldGoalPercent);



        }

        [Fact]
        public void ShouldNotAddTeam()
        {
            Team team = new Team();

            string expectedErrorMessage = "Team must be an NBA team";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(team, new ValidationContext(team), validationResult);
            string actualErrorMessage = validationResult[0].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);

        }


        [Fact]
        public void ShouldListAllTeams()
        {
            //mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 3;

            //TeamController teamController = new TeamController(mockTeamRepo.Object);

            ViewResult result = teamController.ListAllTeams() as ViewResult;
            List<Team> resultModel = result.Model as List<Team>;
            int actualNumberOfTeamsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamsInList);

            //ApplicationDbContext database = null;


            //TeamController teamController = new TeamController(database);
            //teamController.ListAllTeams();


        }

        [Fact]
        public void ShouldSearchForTeamsByName()
        {
            //mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);


            int expectedNumberOfTeamsInList = 1;

            //TeamController teamController = new TeamController(mockTeamRepo.Object);

            string teamName = "Test Team 1";
            string city = null;
            string division = null;
            int? minWins = null;
            int? maxWins = null;
            int? minLosses = null;
            int? maxLosses = null;

            SearchForTeamsViewModel viewModel = new SearchForTeamsViewModel();
            viewModel.Name = teamName;
            viewModel.City = city;
            viewModel.Division = division;
            viewModel.MinWins = minWins;
            viewModel.MaxWins = maxWins;
            viewModel.MinLosses = minLosses;
            viewModel.MaxLosses = maxLosses;
            viewModel.UserFirstVisit = "No";

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }

        [Fact]
        public void ShouldSearchForTeamsByCity()
        {
            //mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 2;

            //TeamController teamController = new TeamController(mockTeamRepo.Object);

            string teamName = null;
            string city = "LA";
            string division = null;
            int? minWins = null;
            int? maxWins = null;
            int? minLosses = null;
            int? maxLosses = null;


            SearchForTeamsViewModel viewModel = new SearchForTeamsViewModel();
            viewModel.Name = teamName;
            viewModel.City = city;
            viewModel.Division = division;
            viewModel.MinWins = minWins;
            viewModel.MaxWins = maxWins;
            viewModel.MinLosses = minLosses;
            viewModel.MaxLosses = maxLosses;
            viewModel.UserFirstVisit = "No";

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }

        [Fact]
        public void ShouldSearchForTeamsByDivision()
        {
            //mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 2;

            //TeamController teamController = new TeamController(mockTeamRepo.Object);

            string teamName = null;
            string city = null;
            string division = "West";
            int? minWins = null;
            int? maxWins = null;
            int? minLosses = null;
            int? maxLosses = null;


            SearchForTeamsViewModel viewModel = new SearchForTeamsViewModel();
            viewModel.Name = teamName;
            viewModel.City = city;
            viewModel.Division = division;
            viewModel.MinWins = minWins;
            viewModel.MaxWins = maxWins;
            viewModel.MinLosses = minLosses;
            viewModel.MaxLosses = maxLosses;
            viewModel.UserFirstVisit = "No";

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }

        [Fact]
        public void ShouldSearchForTeamsByMinWins()
        {
            //mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 1;

            //TeamController teamController = new TeamController(mockTeamRepo.Object);

            string teamName = null;
            string city = null;
            string division = null;
            int? minWins = 6;
            int? maxWins = null;
            int? minLosses = null;
            int? maxLosses = null;


            SearchForTeamsViewModel viewModel = new SearchForTeamsViewModel();
            viewModel.Name = teamName;
            viewModel.City = city;
            viewModel.Division = division;
            viewModel.MinWins = minWins;
            viewModel.MaxWins = maxWins;
            viewModel.MinLosses = minLosses;
            viewModel.MaxLosses = maxLosses;
            viewModel.UserFirstVisit = "No";

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }


        public List<Team> CreateMockTeamData()
        {
            List<Team> mockTeams = new List<Team>();

            Team team = new Team("Test Team 1", "LA", "West", 5, 8);
            mockTeams.Add(team);

            team = new Team("Test Team 2", "Boston", "East", 10, 3);
            mockTeams.Add(team);

            team = new Team("Test Team 3", "LA", "West", 0, 13);
            mockTeams.Add(team);

            return mockTeams;
        }
    }
}
