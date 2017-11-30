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
        public void shouldCheckIfPointsAreZero()
        {
            sut.isGameOver();

            mockPlayer.Verify(player => player.isPointsZero());
        }

        [Fact]
        public void shouldCheckBetting()
        {
            string inputBet = "10";

            sut.checkBetting(inputBet);

            mockPlayer.Verify(player => player.checkBetting(inputBet));
        }

        [Fact]
        public void shouldThrowExceptionWhenBetIsOutOfRange()
        {
            string inputBet = "101";

            mockPlayer.Setup(player => player.checkBetting(inputBet)).Throws(new ArgumentOutOfRangeException());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.checkBetting(inputBet));
        }

        [Fact]
        public void shouldNotRollDiceWhenBetIsHigherThanPoints()
        {
            string inputBet = "120";

            mockPlayer.Setup(player => player.checkBetting(inputBet)).Throws(new ArgumentOutOfRangeException());

            mockDice1.Verify(dice1 => dice1.rollDice(), Times.Never());
            mockDice2.Verify(dice2 => dice2.rollDice(), Times.Never());
        }

        [Fact]
        public void shouldRollDiceWhenBetIsLowerThanPoints()
        {
            string inputBet = "10";

            mockPlayer.Setup(player => player.checkBetting(inputBet)).Returns(true);

            sut.rollDice();

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

        [Fact]
        public void shouldReturnFalseIfSumOfDiceIsNotSeven()
        {            
            int sumOfDice = 5;

            bool actual = sut.isWinner(sumOfDice);

            Assert.False(actual);
        }

        [Fact]
        public void shouldAddPointsWhenPlayerIsWinner()
        {
            bool isWinner = true;
            string bet = "10";
            int plusPoints = 10;

            sut.updatePoints(isWinner, bet);

            mockPlayer.Verify(player => player.addPoints(plusPoints));
        }

        [Fact]
        public void shouldRemovePointsWhenPlayerIsLoser()
        {
            bool isWinner = false;
            string bet = "60";
            int minusPoints = 60;

            sut.updatePoints(isWinner, bet);

            mockPlayer.Verify(player => player.removePoints(minusPoints));
        }
    }
}