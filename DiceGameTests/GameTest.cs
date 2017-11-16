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
            sut.run();

            mockView.Verify(view => view.showMenu());
            mockView.Verify(view => view.showQuitMessage());
        }
    }
}