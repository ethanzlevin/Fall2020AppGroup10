using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Fall2020TestGroup10
{
    public class PlayerTest
    {
        private Mock<IPlayerRepo> mockPlayerRepo;
        private Mock<ITeamRepo> mockTeamRepo;

        private PlayerController playerController;


        public PlayerTest()
        {
            mockPlayerRepo = new Mock<IPlayerRepo>();
            mockTeamRepo = new Mock<ITeamRepo>();

            playerController = new PlayerController(mockPlayerRepo.Object, mockTeamRepo.Object);
        }

        [Fact]
        public void ShouldAddPlayers() //happy path
        {
            //1. Arrange
            DateTime dateOfBirth = new DateTime(2021, 1, 1);
            Player player = new Player();
            player.PlayerID = 5;
            mockPlayerRepo.Setup(m => m.AddPlayer(player));

            //2. Act
            playerController.AddPlayer(player);

            //3. Assert
            mockPlayerRepo.Verify(p => p.AddPlayer(player), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddPlayers() //sad path
        {
            //1. Arrange
            Player player = new Player();

            var validationResult = new List<ValidationResult>();

            //2. Act
            bool isValid = Validator.TryValidateObject(player, new ValidationContext(player), validationResult);

            //3. Assert
            Assert.False(isValid);

        }

        [Fact]
        public void ShouldListAllPlayers()
        {
            //1. Arrange

            List<Player> mockPlayer = CreateMockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayer);

            int expectedNumberOfPlayersInList = 3;

            //2. Act

            ViewResult result = playerController.ListAllPlayers() as ViewResult;
            List<Player> resultModel = result.Model as List<Player>;
            int actualNumberOfPlayersInList = resultModel.Count;

            //3. Assert (Comparing: Expecting v Actual)
            Assert.Equal(expectedNumberOfPlayersInList, actualNumberOfPlayersInList);
        }

        [Fact]
        public void ShouldSearchForPlayers()
        {
            //AAA
            //1. Arrange

            List<Player> mockPlayer = CreateMockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayer);
            mockTeamRepo.Setup(m => m.ListAllTeams()).Returns(new List<Team>());

            int expectedNumberOfPlayersInList = 1;

            SearchForPlayerViewModel viewModel = new SearchForPlayerViewModel();
            viewModel.TeamID = 5;
            viewModel.Position = "TestPosition1";
            viewModel.LastName = "LastName1";
            viewModel.UserFirstVisit = "No";

            //2. Act
            ViewResult result = playerController.SearchForPlayers(viewModel) as ViewResult;
            List<Player> resultPlayerList = viewModel.ResultList;
            int actualNumberOfPlayersInList = resultPlayerList.Count;

            //3. Assert
            Assert.Equal(expectedNumberOfPlayersInList, actualNumberOfPlayersInList);
        }

        public List<Player> CreateMockPlayerData()
        {
            List<Player> mockPlayers = new List<Player>();

            Player player = new Player(5, "FirstName1", "LastName1", DateTime.Today, "TestPosition1", 2016, 12345, 37, 12, 62);
            mockPlayers.Add(player);

            player = new Player(5, "FirstName2", "LastName2", DateTime.Today, "TestPosition2", 2012, 12346, 32, 42, 32);
            mockPlayers.Add(player);

            player = new Player(5, "FirstName3", "LastName3", DateTime.Today, "TestPosition3", 2017, 12347, 35, 28, 72);
            mockPlayers.Add(player);

            return mockPlayers;
        }
    }
}
