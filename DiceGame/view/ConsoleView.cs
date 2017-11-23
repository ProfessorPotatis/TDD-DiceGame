using System;
using System.IO;

namespace DiceGame.View
{
    public class ConsoleView : IConsoleView
    {
        private StringWriter _output;
        public const string MENU = "Dice Game Menu\nPress any key to play or 'q' to quit";
        public const string QUIT = "Thank you for playing and welcome back next time";
        public const string BET = "Place your bet: ";
        public const string QUIT_OPTION = "q";
        public const string YOU_BET = "You bet: ";
        public const string ROLL = "Rolling the dice...";

        public ConsoleView(StringWriter output)
        {
            Output = output;
            //Console.SetOut(Output); // Only for testing
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

            if (quit == QUIT_OPTION)
            {
                return true;
            }
            return false;
        }

        public string getUserBet()
        {
            string bet = Console.ReadLine();
            Console.WriteLine(YOU_BET + "{0}", bet);
            return bet;
        }

        public void showRollMessage()
        {
            
        }
    }
}