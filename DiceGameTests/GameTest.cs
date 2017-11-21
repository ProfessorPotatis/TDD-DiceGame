using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTest
    {
        private Game sut;

        [Fact]
        public void shouldShowMenuAndQuit()
        {
            Mock<IConsoleView> mockView = new Mock<IConsoleView>();
            mockView.Setup(mock => mock.showMenu());

            sut = new Game(mockView.Object);
            
            mockView.Setup(mock => mock.userQuits()).Returns(true);

            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showBetting(), Times.Never());
            mockView.Verify(view => view.showQuitMessage());
        }

        [Fact]
        public void shouldShowMenuAndBetting()
        {
            Mock<IConsoleView> mockView = new Mock<IConsoleView>();
            mockView.Setup(mock => mock.showMenu());

            sut = new Game(mockView.Object);

            mockView.Setup(mock => mock.userQuits()).Returns(false);

            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showBetting());
        }
    }
}