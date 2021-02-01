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

namespace Fall2020TestGroup10
{    
    public class TestTeam
    {
        private Mock<ITeamRepo> mockTeamRepo;

        [Fact]
        public void ShouldListAllTeams()
        {
            mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 3;

            TeamController teamController = new TeamController(mockTeamRepo.Object);

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
            mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 1;

            TeamController teamController = new TeamController(mockTeamRepo.Object);

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

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }

        [Fact]
        public void ShouldSearchForTeamsByDivision()
        {
            mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 2;

            TeamController teamController = new TeamController(mockTeamRepo.Object);

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

            ViewResult result = teamController.SearchForTeams(viewModel) as ViewResult;
            SearchForTeamsViewModel resultModel = result.Model as SearchForTeamsViewModel;
            int actualNumberOfTeamInList = resultModel.ResultTeamList.Count;

            Assert.Equal(expectedNumberOfTeamsInList, actualNumberOfTeamInList);
        }

        [Fact]
        public void ShouldSearchForTeamsByMinWins()
        {
            mockTeamRepo = new Mock<ITeamRepo>();

            List<Team> mockTeams = CreateMockTeamData();
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(mockTeams);

            int expectedNumberOfTeamsInList = 1;

            TeamController teamController = new TeamController(mockTeamRepo.Object);

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
