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
        private ConsoleView sut;

        // Setup
        public ConsoleViewTest()
        {
            sut = new ConsoleView();
        }

        [Fact]
        public void shouldShowMenu()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showMenu();

                string expected = ConsoleView.MENU;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowQuitMessage()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showQuitMessage();

                string expected = ConsoleView.QUIT;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowPlayerPoints()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                int points = 100;

                sut.showPlayerPoints(points);

                string expected = "You have " + points + " points.";
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowGameOverMessage()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showGameOver();

                string expected = ConsoleView.GAME_OVER;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowBetting()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showBetting();

                string expected = ConsoleView.BET;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldGetUserBet()
        {
            using (StringWriter strW = new StringWriter())
            {
                using (StringReader sr = new StringReader("1000"))
                {
                    Console.SetOut(strW);
                    Console.SetIn(sr);

                    string bet = sut.getUserBet();

                    string expected = ConsoleView.YOU_BET + bet;
                    string actual = strW.ToString();

                    Assert.Contains(expected, actual);
                    Assert.Equal(bet, "1000");
                }
            }
        }

        [Fact]
        public void shouldShowExceptionMessage()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showException("\nBet is out of range.");

                string expected = "\nBet is out of range.";
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowRollMessage()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                sut.showRollMessage();

                string expected = ConsoleView.ROLL;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowDiceValues()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);

                int[] dice = {1, 5};

                sut.showDiceValues(dice);

                string expected = "\nDice 1: " + dice[0] + "\nDice 2: " + dice[1];
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowPlayerAsWinner()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                bool isWinner = true;

                sut.showWinner(isWinner);

                string expected = ConsoleView.WINNER;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void shouldShowPlayerAsLoser()
        {
            using (StringWriter strW = new StringWriter())
            {
                Console.SetOut(strW);
                
                bool isWinner = false;

                sut.showWinner(isWinner);

                string expected = ConsoleView.LOSER;
                string actual = strW.ToString();

                Assert.Contains(expected, actual);
            }
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