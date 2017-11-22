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

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.BET));
        }

        [Fact]
        public void shouldGetUserBet()
        {
            using (StringReader sr = new StringReader("1000"))
            {
                Console.SetIn(sr);

                string bet = sut.getUserBet();

                stringWriter.Verify(sw => sw.WriteLine(bet));
                Assert.Equal(bet, "1000");
            }
        }

        [Fact]
        public void shouldReturnTrueWhenUserQuits()
        {
            using (StringReader sr = new StringReader("q"))
            {
                Console.SetIn(sr);

                bool userQuits = sut.userQuits();

                Assert.Equal(userQuits, true);
            }
        }

        [Fact]
        public void shouldReturnFalseWhenUserDoesNotQuit()
        {
            using (StringReader sr = new StringReader(""))
            {
                Console.SetIn(sr);

                bool userQuits = sut.userQuits();

                Assert.Equal(userQuits, false);
            }
        }

        public void Dispose()
        {

        }
    }
}