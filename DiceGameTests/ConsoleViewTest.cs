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
        public void shouldShowPlayerPoints()
        {
            int points = 100;

            sut.showPlayerPoints(points);

            stringWriter.Verify(sw => sw.WriteLine("Player has " + points + " points."));
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

                stringWriter.Verify(sw => sw.WriteLine(ConsoleView.YOU_BET + bet));
                Assert.Equal(bet, "1000");
            }
        }

        [Fact]
        public void shouldShowExceptionMessage()
        {
            sut.showException("\nBet is out of range.");

            stringWriter.Verify(sw => sw.WriteLine("\nBet is out of range."));
        }

        [Fact]
        public void shouldShowRollMessage()
        {
            sut.showRollMessage();

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.ROLL));
        }

        [Fact]
        public void shouldShowDiceValues()
        {
            int[] dice = {1, 5};

            sut.showDiceValues(dice);

            stringWriter.Verify(sw => sw.WriteLine("\nDice 1: " + dice[0]));
            stringWriter.Verify(sw => sw.WriteLine("Dice 2: " + dice[1]));
        }

        [Fact]
        public void shouldShowPlayerAsWinner()
        {
            bool isWinner = true;

            sut.showWinner(isWinner);

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.WINNER));
        }

        [Fact]
        public void shouldShowPlayerAsLoser()
        {
            bool isWinner = false;

            sut.showWinner(isWinner);

            stringWriter.Verify(sw => sw.WriteLine(ConsoleView.LOSER));
        }

        [Fact]
        public void shouldReturnTrueWhenUserQuits()
        {
            using (StringReader sr = new StringReader(ConsoleView.QUIT_OPTION))
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