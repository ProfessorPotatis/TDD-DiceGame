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
        public void shouldCheckBettingAndReturnFalse()
        {
            string bet = "120";

            bool actual = sut.checkBetting(bet);

            Assert.False(actual);
        }
    }
}