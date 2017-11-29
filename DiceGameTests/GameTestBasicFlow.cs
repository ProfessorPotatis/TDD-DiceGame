using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTestBasicFlow : SetupForGameTest
    {
        private int points;
        private string inputBet;

        // Setup
        public override void Setup()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            points = 100;
            mockModel.Setup(model => model.getPlayerPoints()).Returns(points);

            inputBet = "10";
            mockView.Setup(mock => mock.getUserBet()).Returns(inputBet);
        }

        [Fact]
        public void shouldShowMenu()
        {
            sut.run();

            mockView.Verify(view => view.showMenu());
        }

        [Fact]
        public void shouldShowBetting()
        {
            sut.run();

            mockView.Verify(view => view.showBetting());
        }

        [Fact]
        public void shouldGetPlayerPoints()
        {
            sut.run();

            mockModel.Verify(model => model.getPlayerPoints());
        }

        [Fact]
        public void shouldShowPlayerPoints()
        {
            sut.run();

            mockView.Verify(view => view.showPlayerPoints(points));
        }

        [Fact]
        public void shouldAskUserToBet()
        {
            sut.run();

            mockView.Verify(view => view.getUserBet());
        }

        [Fact]
        public void shouldShowRollMessage()
        {
            sut.run();

            mockView.Verify(view => view.showRollMessage());
        }

        [Fact]
        public void shouldHandleGameRules()
        {
            sut.run();

            mockModel.Verify(model => model.runGame(inputBet));
        }
    }
}