using System;
using System.IO;

namespace DiceGame.View
{
    public class ConsoleView : IConsoleView
    {
        private StringWriter _output;
        public const string MENU = "Dice Game Menu\n Bet (h)igher or (l)ower or (q)uit";

        public ConsoleView(StringWriter output)
        {
            Output = output;
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
            Output.WriteLine(MENU);
        }

        public void showQuitMessage()
        {
            
        }
        
    }
}