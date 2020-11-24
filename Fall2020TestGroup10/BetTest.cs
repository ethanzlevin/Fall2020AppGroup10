using Fall2020AppGroup10.Controllers;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class BetTest
{
    private Mock<IBetRepo> mockBetRepo;

    [Fact]
    public void ShouldListAllBets()
    {
        mockBetRepo = new Mock<IBetRepo>();

        List<Bet> mockBets = CreateMockBetData();
        mockBetRepo.Setup(m => m.ListAllBets()).Returns(mockBets);

        int expectedNumberOfBetsInList = 3;

        BetController betController = new BetController(mockBetRepo.Object);

        ViewResult result = betController.ListAllBets() as ViewResult;
        List<Bet> resultModel = result.Model as List<Bet>;
        int actualNumberOfBetsInList = resultModel.Count;

        Assert.Equal(expectedNumberOfBetsInList, actualNumberOfBetsInList);

    }

    public List<Bet> CreateMockBetData()
    {
        List<Bet> mockBets = new List<Bet>();

        DateTime startdate = new DateTime(2020, 11, 9);
        DateTime enddate = new DateTime(2020, 11, 11);

        Bet bet = new Bet(14.99m, 50.87m, startdate, enddate, "Correct", "1", 1, null);
        mockBets.Add(bet);

        bet = new Bet(5.55m, 20.47m, startdate, enddate, "Wrong", "2", null, 1);
        mockBets.Add(bet);

        bet = new Bet(50.69m, 125.90m, startdate, enddate, "Wrong", "3", null, 2);
        mockBets.Add(bet);

        return mockBets;
    }
}