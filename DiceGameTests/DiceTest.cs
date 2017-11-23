using System;
using Xunit;
using Moq;
using DiceGame.Model;

namespace DiceGameTests
{
    public class DiceTest
    {
        private Mock<Random> die;
        private Dice sut;

        // Setup
        public DiceTest()
        {
            die = new Mock<Random>();
            sut = new Dice();
        }

        [Fact]
        public void shouldRollSixSidedDice()
        {
            int actual = sut.rollDice();

            Assert.InRange(actual, 1, 6);
        }
    }
}