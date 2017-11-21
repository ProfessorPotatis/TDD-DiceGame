using System;
using System.IO;

namespace DiceGame.View
{
    public class ConsoleView : IConsoleView
    {
        private StringWriter _output;
        private StringReader _input;
        public const string MENU = "Dice Game Menu\n Bet (h)igher or (l)ower or (q)uit";
        public const string QUIT = "Thank you for playing and welcome back next time";
        public const string BET = "Place your bet: ";

        public ConsoleView(StringWriter output, StringReader input)
        {
            Output = output;
            Input = input;
        }

        public StringWriter Output
        {
            get { return _output; }
            set
            {
                _output = value;
            }
        }

        public StringReader Input
        {
            get { return _input; }
            set
            {
                _input = value;
            }
        }

        public void showMenu()
        {
            Output.WriteLine(MENU);
        }

        public void showQuitMessage()
        {
            Output.WriteLine(QUIT);
        }

        public void showBetting()
        {
            Output.WriteLine(BET);
        }

        public bool userQuits()
        {
            return false;
        }

        public int getUserBet()
        {
            return 0;
        }
    }
}