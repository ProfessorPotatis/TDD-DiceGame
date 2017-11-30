using System;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Model;
using DiceGame.Controller;

namespace DiceGameTests
{
    public abstract class SetupForGameTest
    {
        protected Mock<IConsoleView> mockView;
        protected Mock<IDiceGameModel> mockModel;
        protected Mock<IPlayer> mockPlayer;
        protected Game sut;

        public SetupForGameTest()
        {
            mockView = new Mock<IConsoleView>();
            mockModel = new Mock<IDiceGameModel>();
            mockPlayer = new Mock<IPlayer>();

            Setup();

            sut = new Game(mockView.Object, mockModel.Object);
        }

        public abstract void Setup();

    }
}