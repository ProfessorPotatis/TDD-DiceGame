using System;
using System.IO;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter stringWriter = new StringWriter();
            View.IConsoleView view = new View.ConsoleView(stringWriter);
            Controller.Game game = new Controller.Game(view);

            game.run();
        }
    }
}
