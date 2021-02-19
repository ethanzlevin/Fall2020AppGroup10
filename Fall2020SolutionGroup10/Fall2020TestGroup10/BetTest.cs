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
    public class BetTest
    {
        private Mock<IBetRepo> mockBetRepo;

        [Fact]
        public void ShouldListAllBets()
        {
            mockBetRepo = new Mock<IBetRepo>();

            List<Bet> mockBets = CreateMockBetData();
            mockBetRepo.Setup(m => m.ListAllBets()).Returns(mockBets);

            int expectedNumberOfBetsInList = 4;

            BetController betController = new BetController(mockBetRepo.Object);

            ViewResult result = betController.ListAllBets() as ViewResult;
            List<Bet> resultModel = result.Model as List<Bet>;
            int actualNumberOfBetsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfBetsInList, actualNumberOfBetsInList);

        }
        [Fact]
        public void ShouldSearchAllBetsByUser()
        {
            mockBetRepo = new Mock<IBetRepo>();

            List<Bet> mockBets = CreateMockBetData();
            mockBetRepo.Setup(m => m.ListAllBets()).Returns(mockBets);
            mockBetRepo.Setup(m => m.ListAllUsers()).Returns(new List<User>());


            int expectedNumberOfBetsInList = 2;
            SearchForBetsViewModel viewModel = new SearchForBetsViewModel();
            viewModel.UserID = "2";
            BetController betController = new BetController(mockBetRepo.Object);

            ViewResult result = betController.SearchForBets(viewModel) as ViewResult;

            SearchForBetsViewModel resultModel = result.Model as SearchForBetsViewModel;
            int actualNumberOfBetsInList = resultModel.BetResultList.Count;

            Assert.Equal(expectedNumberOfBetsInList, actualNumberOfBetsInList);

        }

        public List<Bet> CreateMockBetData()
        {
            List<Bet> mockBets = new List<Bet>();

            DateTime startdate = new DateTime(2020, 11, 9);
            DateTime enddate = new DateTime(2020, 11, 11);
            decimal amt = 105;

            bool win = true;

            


            PlayerBet playerbet = new PlayerBet(amt, startdate, enddate, win, "1" , 100, 19, "Rebounds", 5);
            mockBets.Add(playerbet);
             playerbet = new PlayerBet(amt, startdate, enddate, true, "2", 100, 19, "Rebounds", 5);
            mockBets.Add(playerbet);
            playerbet = new PlayerBet(amt, startdate, enddate, true, "2", 100, 19, "Rebounds", 5);
            mockBets.Add(playerbet);
            playerbet = new PlayerBet(amt, startdate, enddate, true, "3", 100, 19, "Rebounds", 5);
            mockBets.Add(playerbet);

            
            return mockBets;
        }
    }
}