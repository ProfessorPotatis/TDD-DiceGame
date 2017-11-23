using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTest
    {
        private Mock<IConsoleView> mockView;
        private Mock<IDiceGameModel> mockModel;
        private Mock<IPlayer> mockPlayer;
        private Game sut;

        // Setup
        public GameTest()
        {
            mockView = new Mock<IConsoleView>();
            mockModel = new Mock<IDiceGameModel>();
            mockPlayer = new Mock<IPlayer>();
            sut = new Game(mockView.Object, mockModel.Object);
        }

        [Fact]
        public void shouldShowMenuAndQuit()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(true);

            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showBetting(), Times.Never());
            mockView.Verify(view => view.showQuitMessage());
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
            mockPlayer.Verify(player => player.getPlayerPoints());
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
    }
}