using System;
using Xunit;
using Moq;
using DiceGame.Model;
using DiceGame.View;

namespace DiceGameTests
{
    public class DiceGameModelTest
    {
        private Mock<IDice> mockDice1;
        private Mock<IDice> mockDice2;
        private Mock<IDiceGameModel> mockModel;
        private DiceGameModel sut;

        // Setup
        public DiceGameModelTest()
        {
            mockDice1 = new Mock<IDice>();
            mockDice2 = new Mock<IDice>();
            mockModel = new Mock<IDiceGameModel>();
            sut = new DiceGameModel(mockDice1.Object, mockDice2.Object);
        }

        [Fact]
        public void shouldRollTwoDice()
        {
            string inputBet = "10";

            sut.runGame(inputBet);

            mockDice1.Verify(dice1 => dice1.rollDice());
            mockDice2.Verify(dice2 => dice2.rollDice());
        }
    }
}