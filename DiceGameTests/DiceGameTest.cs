using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class DiceGameTest
    {
        private Game sut;

        [Fact]
        public void shouldCallShowMenu()
        {
            Mock<IConsoleView> mockView = new Mock<IConsoleView>();
            mockView.Setup(mock => mock.showMenu());

            sut = new Game(mockView.Object);
            sut.run();

            mockView.Verify(view => view.showMenu());
        }
    }
}