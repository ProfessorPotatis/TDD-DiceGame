/*using System;
using Xunit;
using Moq;
using DiceGame.Model;
using DiceGame.View;

namespace DiceGameTests
{
    public class DiceGameModelTest
    {
        private DiceGameModel sut;
        private Mock<IDice> mockDice;
        private Mock<IDiceGameModel> mockModel;
        private Mock<IConsoleView> mockView;

        // Setup
        public DiceGameModelTest()
        {
            mockDice = new Mock<IDice>();
            mockModel = new Mock<IDiceGameModel>();
            mockView = new Mock<IConsoleView>();
            sut = new DiceGameModel();
        }

        [Fact]
        public void shouldRollTwoDice()
        {
            string inputBet = "20";

            sut.runGame(inputBet);

            
        }

        [Fact]
        public void shouldReturnFalseIfPlayerIsNotWinner()
        {
            bool actual = sut.runGame("10");

            Assert.False(actual);
        }

    }
}*/