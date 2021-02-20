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
        private BetController betController;

        public BetTest()
        {
            mockBetRepo = new Mock<IBetRepo>();
            betController = new BetController(mockBetRepo.Object);

        }
        [Fact]
        public void ShouldPlaceBet()
        {
            PlayerBet playerBet = new PlayerBet(10, new DateTime(2021, 02, 20), null, null, "005", -199, 10, "Rebounds", 10);

            GameBet gameBet = new GameBet(10, new DateTime(2021, 02, 20), null, null, "004", 240, "Home", 20);

            mockBetRepo.Setup(m => m.AddBet(playerBet));

            mockBetRepo.Setup(m => m.AddBet(gameBet));


            betController.AddBet(gameBet);
            betController.AddBet(playerBet);


        }
        [Fact]
        public void ShouldNotPlaceBet()
        {

        }

        [Fact]
        public void ShouldListAllBets()
        {
            

            List<Bet> mockBets = CreateMockBetData();
            mockBetRepo.Setup(m => m.ListAllBets()).Returns(mockBets);

            int expectedNumberOfBetsInList = 4;

            

            ViewResult result = betController.ListAllBets() as ViewResult;
            List<Bet> resultModel = result.Model as List<Bet>;
            int actualNumberOfBetsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfBetsInList, actualNumberOfBetsInList);

        }
        [Fact]
        public void ShouldSearchAllBetsByUser()
        {
          

            List<Bet> mockBets = CreateMockBetData();
            mockBetRepo.Setup(m => m.ListAllBets()).Returns(mockBets);
            mockBetRepo.Setup(m => m.ListAllUsers()).Returns(new List<User>());


            int expectedNumberOfBetsInList = 2;
            SearchForBetsViewModel viewModel = new SearchForBetsViewModel();
            viewModel.UserID = "2";

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