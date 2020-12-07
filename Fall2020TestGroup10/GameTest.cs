using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace Fall2020TestGroup10
{
    public class GameTest
    {
        private Mock<IGameRepo> mockGameRepo;

        [Fact]
        public void ShouldListAllGames()
        {
            mockGameRepo = new Mock<IGameRepo>();

            List<Game> mockGames = CreateMockGameData();
            mockGameRepo.Setup(m => m.ListAllGames()).Returns(mockGames);

            int expectedNumberOfGamesInList = 3;

            GameController gameController = new GameController(mockGameRepo.Object);

            ViewResult result = gameController.ListAllGames() as ViewResult;
            List<Game> resultModel = result.Model as List<Game>;
            int actualNumberOfGamesInList = resultModel.Count;

            Assert.Equal(expectedNumberOfGamesInList, actualNumberOfGamesInList);

        }


        [Fact]
        public void ShouldSearchForGameByDate()
        {
            mockGameRepo = new Mock<IGameRepo>();

            List<Game> mockGames = CreateMockGameData();
            mockGameRepo.Setup(m => m.ListAllGames()).Returns(mockGames);

            int expectedNumberOfGameInList = 1;

            GameController gameController = new GameController(mockGameRepo.Object);


            int? teamID = null;
            int? homeID = null;
            int? awayID = null;
            DateTime? startDate = new DateTime(2020, 11, 1);
            DateTime? endDate = new DateTime(2020, 11, 30);

            ViewResult result = gameController.SearchForGames(teamID, homeID, awayID, startDate, endDate) as ViewResult;
            List<Game> resultModel = result.Model as List<Game>;
            int actualNumberOfGamesInList = resultModel.Count;

            Assert.Equal(expectedNumberOfGameInList, actualNumberOfGamesInList);



        }



        public List<Game> CreateMockGameData()
        {
            List<Game> mockGames = new List<Game>();

            int testHomeID = 1;
            int testawayID = 2;

            DateTime GameTime = new DateTime(2020, 11, 9);

            Game game = new Game(GameTime, true, 35, testHomeID, testawayID);
            mockGames.Add(game);
            


            GameTime = new DateTime(2020, 10, 19);

            game = new Game(GameTime, false, 74, 3, 5);
            mockGames.Add(game);

            GameTime = new DateTime(2020, 1, 29);

            game = new Game(GameTime, true, 43, 8, 9);
            mockGames.Add(game);

            return mockGames;
        }
    }
}