using System;
using System.IO;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class ConsoleViewTest : IDisposable
    {
        private Mock<StringWriter> stringWriter;
        private ConsoleView sut;

        // Setup
        public ConsoleViewTest()
        {
            stringWriter = new Mock<StringWriter>();
            sut = new ConsoleView(stringWriter.Object);
        }

        [Fact]
        public void shouldShowMenu()
        {
            sut.showMenu();

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.MENU));
        }

        [Fact]
        public void shouldShowQuitMessage()
        {
            sut.showQuitMessage();

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.QUIT));
        }

        [Fact]
        public void shouldShowBetting()
        {
            sut.showBetting();

            stringWriter.Verify(sw => sw.WriteLine("Place your bet: "));
        }

        public void Dispose()
        {

        }
    }
}