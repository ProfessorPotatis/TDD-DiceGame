using System;
using System.IO;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class ConsoleViewTest
    {
        private ConsoleView sut;

        [Fact]
        public void shouldShowMenu()
        {
            Mock<StringWriter> stringWriter = new Mock<StringWriter>();

            sut = new ConsoleView(stringWriter.Object);

            sut.showMenu();

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.MENU));
        }

        [Fact]
        public void shouldShowQuitMessage()
        {
            Mock<StringWriter> stringWriter = new Mock<StringWriter>();

            sut = new ConsoleView(stringWriter.Object);

            sut.showQuitMessage();

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.QUIT));
        }
    }
}