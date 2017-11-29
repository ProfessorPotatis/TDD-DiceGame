using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTest : SetupForGameTest
    {
        

        // Setup
        public override void Setup()
        {
            
        }

        [Fact]
        public void shouldShowMenuAndBetting()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showBetting());
        }

        [Fact]
        public void shouldGetPlayerPoints()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            sut.run();

            mockModel.Verify(model => model.getPlayerPoints());
        }

        [Fact]
        public void shouldShowPlayerPoints()
        {
            int points = 100;

            mockModel.Setup(model => model.getPlayerPoints()).Returns(points);

            sut.run();

            mockView.Verify(view => view.showPlayerPoints(points));
        }

        [Fact]
        public void shouldAskUserToBet()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            sut.run();

            mockView.Verify(view => view.getUserBet());
        }

        [Fact]
        public void shouldShowRollMessage()
        {
            mockView.Setup(mock => mock.getUserBet()).Returns("10");

            sut.run();

            mockView.Verify(view => view.showRollMessage());
        }

        [Fact]
        public void shouldHandleGameRules()
        {
            string inputMoney = "10";

            mockView.Setup(mock => mock.getUserBet()).Returns(inputMoney);

            sut.run();

            mockModel.Verify(model => model.runGame(inputMoney));
        }


        // THIS TEST MIGHT BE GIVING FALSE POSITIVE RESULT!!
        [Fact]
        public void shouldCatchExpectionAndShowExceptionMessage()
        {
            mockView = new Mock<IConsoleView>();
            mockModel = new Mock<IDiceGameModel>();

            try
            {
                mockModel.Setup(mock => mock.runGame("200")).Throws(new ArgumentOutOfRangeException());

                sut = new Game(mockView.Object, mockModel.Object);

                sut.run();
                //Assert.True(false);
            } catch (ArgumentOutOfRangeException)
            {
                Assert.False(true);
            }    

            mockView.Verify(view => view.showException(It.IsAny<string>()));       
        }
    }
}