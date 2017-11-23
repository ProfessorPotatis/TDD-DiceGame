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
        public void shouldRollSixSidedDie()
        {
            int actual = sut.rollDice();

            Assert.InRange(actual, 1, 6);
        }

        [Fact]
        public void shouldRollTwoSixSidedDie()
        {
            int die1 = sut.rollDice();
            int die2 = sut.rollDice();

            Assert.InRange(die1, 1, 6);
            Assert.InRange(die2, 1, 6);
            Assert.NotEqual(die1, die2);
        }
    }
}