using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTestExceptions : SetupForGameTest
    {
        private int points;
        private string inputBet;
        private string notANumber;

        // Setup
        public override void Setup()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            points = 100;
            mockModel.Setup(model => model.getPlayerPoints()).Returns(points);

            inputBet = "200";
            mockView.Setup(mock => mock.getUserBet()).Returns(inputBet);

            mockModel.Setup(mock => mock.checkBetting(inputBet)).Throws(new ArgumentOutOfRangeException());

            notANumber = "qldj";
            mockModel.Setup(mock => mock.checkBetting(notANumber)).Throws(new FormatException());
        }

        [Fact]
        public void shouldCatchExpectionAndShowExceptionMessage()
        {
            sut.run();
   
            mockView.Verify(view => view.showException(It.IsAny<string>()));       
        }
    }
}