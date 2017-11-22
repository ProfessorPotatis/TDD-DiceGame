using System;
using Xunit;
using Moq;
using DiceGame.Model;

namespace DiceGameTests
{
    public class DiceGameModelTest
    {
        private DiceGameModel sut;
        private Mock<IDice> mockDice;
        private Mock<IDiceGameModel> mockModel;

        [Fact]
        public void shouldRollTwoDice()
        {
            sut.runGame("10");

            mockDice.Verify(die => die.rollDice());
        }

    }
}