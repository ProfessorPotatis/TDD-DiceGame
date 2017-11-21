using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTest
    {
        private Mock<IConsoleView> mockView;
        private Game sut;

        // Setup
        public GameTest()
        {
            mockView = new Mock<IConsoleView>();
            sut = new Game(mockView.Object);
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
    }
}