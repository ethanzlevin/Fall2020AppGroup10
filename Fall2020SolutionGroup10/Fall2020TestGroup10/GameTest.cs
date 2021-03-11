using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;


namespace Fall2020TestGroup10
{
    public class GameTest
    {
        private Mock<IGameRepo> mockGameRepo;
        private Mock<ITeamRepo> mockTeamRepo;
        private GameController gameController;

        public GameTest()
        {
            mockGameRepo = new Mock<IGameRepo>();
            mockTeamRepo = new Mock<ITeamRepo>();
            gameController = new GameController(mockGameRepo.Object, mockTeamRepo.Object);
        }

        [Fact]
        public void ShouldListAllGames()
        {
            

            List<Game> mockGames = CreateMockGameData();
            mockGameRepo.Setup(m => m.ListAllGames()).Returns(mockGames);

            int expectedNumberOfGamesInList = 3;

            

            ViewResult result = gameController.ListAllGames() as ViewResult;
            List<Game> resultModel = result.Model as List<Game>;
            int actualNumberOfGamesInList = resultModel.Count;

            Assert.Equal(expectedNumberOfGamesInList, actualNumberOfGamesInList);

        }


        [Fact]
        public void ShouldSearchForGameByDate()
        {
            

            List<Game> mockGames = CreateMockGameData();
            mockGameRepo.Setup(m => m.ListAllGames()).Returns(mockGames);

            int expectedNumberOfGameInList = 1;

            


            
            int? homeID = null;
            int? awayID = null;
            DateTime? startDate = new DateTime(2020, 11, 1);
            DateTime? endDate = new DateTime(2020, 11, 30);

            ViewResult result = gameController.SearchForGames(homeID, awayID, startDate, endDate) as ViewResult;
            List<Game> resultModel = result.Model as List<Game>;
            int actualNumberOfGamesInList = resultModel.Count;

            Assert.Equal(expectedNumberOfGameInList, actualNumberOfGamesInList);



        }

        [Fact]
        public void ShouldAddNewGame()//happy path
        {
            //1. Arrange
            DateTime dateOfGame = new DateTime(2021, 2, 21);
            Game game = new Game(dateOfGame, true, 65, 4, 7);
            game.GameID = 10;
            mockGameRepo.Setup(g => g.AddGame(game));

            //2. Act
            gameController.AddGame(game);

            //3. Assert (Verification)
            mockGameRepo.Verify(g => g.AddGame(game), Times.Exactly(1));

        }

        [Fact(Skip = "In Progress")]
        public void ShouldNotAddNewGame()//sad path
        {
            //1. Arange
            Game game = new Game();

            var validationResult = new List<ValidationResult>();

            //2. Act
            bool isValid = Validator.TryValidateObject(game, new ValidationContext(game) , validationResult);

            //3. Assert
            Assert.False(isValid);

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