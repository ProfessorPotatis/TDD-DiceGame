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

        /*[Fact]
        public void shouldCheckBetting()
        {
            string inputBet = "10";

            sut.runGame(inputBet);

            mockPlayer.Verify(player => player.checkBetting(inputBet));
        }*/
    }
}