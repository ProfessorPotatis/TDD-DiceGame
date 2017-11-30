using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTestGameOver : SetupForGameTest
    {
        private int points;

        // Setup
        public override void Setup()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            mockModel.Setup(model => model.isGameOver()).Returns(true);
        }

        [Fact]
        public void shouldCheckIfGameIsOver()
        {
            sut.run();

            mockModel.Verify(model => model.isGameOver());
        }

        [Fact]
        public void shouldShowGameOver()
        {
            sut.run();

            mockView.Verify(view => view.showGameOver());
        }
    }
}