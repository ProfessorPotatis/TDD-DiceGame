using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class GameTestBasicFlow : SetupForGameTest
    {
        private int points;
        private string inputBet;
        private int[] dice = {4, 3};
        private int sum;
        private bool isWinner;

        // Setup
        public override void Setup()
        {
            mockView.Setup(mock => mock.userQuits()).Returns(false);

            points = 100;
            mockModel.Setup(model => model.getPlayerPoints()).Returns(points);

            inputBet = "10";
            mockView.Setup(mock => mock.getUserBet()).Returns(inputBet);

            mockModel.Setup(mock => mock.checkBetting(inputBet)).Returns(true);

            mockModel.Setup(mock => mock.rollDice()).Returns(dice);

            sum = 7;
            mockModel.Setup(mock => mock.sumDice(dice[0], dice[1])).Returns(sum);

            isWinner = true;
            mockModel.Setup(mock => mock.isWinner(sum)).Returns(true);
        }

        [Fact]
        public void shouldShowMenu()
        {
            sut.run();

            mockView.Verify(view => view.showMenu());
        }

        [Fact]
        public void shouldShowBetting()
        {
            sut.run();

            mockView.Verify(view => view.showBetting());
        }

        [Fact]
        public void shouldGetPlayerPoints()
        {
            sut.run();

            mockModel.Verify(model => model.getPlayerPoints());
        }

        [Fact]
        public void shouldShowPlayerPoints()
        {
            sut.run();

            mockView.Verify(view => view.showPlayerPoints(points));
        }

        [Fact]
        public void shouldAskUserToBet()
        {
            sut.run();

            mockView.Verify(view => view.getUserBet());
        }

        [Fact]
        public void shouldCheckBetting()
        {
            sut.run();

            mockModel.Verify(model => model.checkBetting(inputBet));
        }

        [Fact]
        public void shouldShowRollMessage()
        {
            sut.run();

            mockView.Verify(view => view.showRollMessage());
        }

        [Fact]
        public void shouldRollDice()
        {
            sut.run();

            mockModel.Verify(model => model.rollDice());
        }

        [Fact]
        public void shouldShowDiceValues()
        {
            sut.run();

            mockView.Verify(view => view.showDiceValues(dice));
        }

        [Fact]
        public void shouldSumDice()
        {
            sut.run();

            mockModel.Verify(model => model.sumDice(dice[0], dice[1]));
        }

        [Fact]
        public void shouldUpdatePoints()
        {
            sut.run();

            mockModel.Verify(model => model.updatePoints(isWinner, inputBet));
        }

        [Fact]
        public void shouldShowWinner()
        {
            sut.run();

            mockView.Verify(view => view.showWinner(isWinner));
        }
    }
}