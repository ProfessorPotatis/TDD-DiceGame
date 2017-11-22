using System;
using System.IO;

namespace DiceGame.View
{
    public class ConsoleView : IConsoleView
    {
        private StringWriter _output;
        public const string MENU = "Dice Game Menu\n Bet (h)igher or (l)ower or (q)uit";
        public const string QUIT = "Thank you for playing and welcome back next time";
        public const string BET = "Place your bet: ";

        public ConsoleView(StringWriter output)
        {
            Output = output;
            Console.SetOut(Output); // Only for testing
        }

        public StringWriter Output
        {
            get { return _output; }
            set
            {
                _output = value;
            }
        }

        public void showMenu()
        {
            Console.WriteLine(MENU);
        }

        public void showQuitMessage()
        {
            Console.WriteLine(QUIT);
        }

        public void showBetting()
        {
            Console.WriteLine(BET);
        }

        public bool userQuits()
        {
            string quit = Console.ReadLine();

            if (quit == "q")
            {
                return true;
            }
            return false;
        }

        public string getUserBet()
        {
            string bet = Console.ReadLine();
            Console.WriteLine("{0}", bet);
            return bet;
        }
    }
}