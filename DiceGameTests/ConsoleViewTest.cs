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
        private Mock<StringReader> stringReader;
        private ConsoleView sut;

        // Setup
        public ConsoleViewTest()
        {
            stringWriter = new Mock<StringWriter>();
            stringReader = new Mock<StringReader>(Console.ReadLine());
            sut = new ConsoleView(stringWriter.Object, stringReader.Object);
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

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.BET));
        }

        [Fact]
        public void shouldGetUserBet()
        {
            int inputBet = sut.getUserBet();

            stringReader.Verify(sr => sr.ReadLine());
        }

        public void Dispose()
        {

        }
    }
}