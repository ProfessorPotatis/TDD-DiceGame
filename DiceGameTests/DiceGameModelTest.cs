using System;
using Xunit;
using Moq;
using DiceGame.Model;

namespace DiceGameTests
{
    public class DiceGameModelTest
    {
        private Mock<IDice> mockDice1;
        private Mock<IDice> mockDice2;
        private Mock<IPlayer> mockPlayer;
        private Mock<IDiceGameModel> mockModel;
        private DiceGameModel sut;

        // Setup
        public DiceGameModelTest()
        {
            mockDice1 = new Mock<IDice>();
            mockDice2 = new Mock<IDice>();
            mockPlayer = new Mock<IPlayer>();
            mockModel = new Mock<IDiceGameModel>();
            sut = new DiceGameModel(mockDice1.Object, mockDice2.Object, mockPlayer.Object);
        }

        [Fact]
        public void shouldGetPlayerPoints()
        {
            mockModel.Setup(model => model.getPlayerPoints());

            sut.getPlayerPoints();

            mockPlayer.Verify(player => player.getPlayerPoints());
        }

        [Fact]
        public void shouldCheckBetting()
        {
            string inputBet = "10";

            sut.runGame(inputBet);

            mockPlayer.Verify(player => player.checkBetting(inputBet));
        }

        [Fact]
        public void shouldNotRollDiceWhenBetIsHigherThanPoints()
        {
            string inputBet = "120";

            mockPlayer.Setup(player => player.checkBetting(inputBet)).Returns(false);

            sut.runGame(inputBet);

            mockDice1.Verify(dice1 => dice1.rollDice(), Times.Never());
            mockDice2.Verify(dice2 => dice2.rollDice(), Times.Never());
        }

        [Fact]
        public void shouldRollDiceWhenBetIsLowerThanPoints()
        {
            string inputBet = "10";

            mockPlayer.Setup(player => player.checkBetting(inputBet)).Returns(true);

            sut.runGame(inputBet);

            mockDice1.Verify(dice1 => dice1.rollDice());
            mockDice2.Verify(dice2 => dice2.rollDice());
        }

        [Fact]
        public void shouldSumRolledDice()
        {
            int[] dice = {3, 4};

            int actual = sut.sumDice(dice[0], dice[1]);

            Assert.Equal(7, actual);
        }

        [Fact]
        public void shouldReturnTrueIfSumOfDiceIsSeven()
        {            
            int sumOfDice = 7;

            bool actual = sut.isWinner(sumOfDice);

            Assert.True(actual);
        }
    }
}