using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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

    public List<Game> CreateMockGameData()
    {
        List<Game> mockGames= new List<Game>();

        DateTime GameTime = new DateTime(2020, 11, 9);
       

        Game game = new Game(GameTime, true, 35, 1, 2);
        mockGames.Add(game);

        game = new Game(GameTime, false, 74, 3, 5);
        mockGames.Add(game);

        game = new Game(GameTime, true, 43, 8, 9);
        mockGames.Add(game);

        return mockGames;
    }
}