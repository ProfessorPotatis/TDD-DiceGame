using System;
using Xunit;
using Moq;
using DiceGame.Model;

namespace DiceGameTests
{
    public class PlayerTest
    {
        private Player sut;

        // Setup
        public PlayerTest()
        {
            sut = new Player();
        }

        [Fact]
        public void shouldReturnPlayerPoints()
        {
            int actual = sut.getPlayerPoints();

            Assert.Equal(100, actual);
        }

        [Fact]
        public void shouldCheckBettingAndReturnTrue()
        {
            string bet = "20";

            bool actual = sut.checkBetting(bet);

            Assert.True(actual);
        }

        [Fact]
        public void shouldCheckBettingAndThrowException()
        {
            string bet = "120";

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.checkBetting(bet));
        }

        [Fact]
        public void shouldAddPoints()
        {
            int plusPoints = 10;

            sut.addPoints(plusPoints);

            int actual = sut.getPlayerPoints();

            Assert.Equal(110, actual);
        }

        [Fact]
        public void shouldRemovePoints()
        {
            int minusPoints = 30;

            sut.removePoints(minusPoints);

            int actual = sut.getPlayerPoints();

            Assert.Equal(70, actual);
        }
    }
}