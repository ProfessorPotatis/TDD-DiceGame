using System;
using System.IO;
using Xunit;
using Moq;
using DiceGame.View;
using DiceGame.Controller;

namespace DiceGameTests
{
    public class ConsoleViewTest : IDisposable
    {
        private ConsoleView sut;

        // Setup
        public ConsoleViewTest()
        {
            sut = new ConsoleView();
        }

        [Fact]
        public void shouldShowMenu()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                sut.showMenu();
        
                string result = sw.ToString();
                Assert.Contains(ConsoleView.MENU, result);
            }
        }

        [Fact]
        public void shouldShowQuitMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                sut.showQuitMessage();
        
                string result = sw.ToString();
                Assert.Contains(ConsoleView.QUIT, result);
            }
        }

        [Fact]
        public void shouldShowBetting()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                sut.showBetting();
        
                string result = sw.ToString();
                Assert.Contains(ConsoleView.BET, result);
            }
        }

        [Fact]
        public void shouldGetUserBet()
        {
            
        }

        public void Dispose()
        {

        }
    }
}