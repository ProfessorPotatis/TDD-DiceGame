using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTestQuit : SetupForGameTest
    {
        public override void Setup()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(true);
        }

        [Fact]
        public void shouldShowMenuAndQuit()
        {
            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showBetting(), Times.Never());
            mockView.Verify(view => view.showQuitMessage());
        }
    }
}