using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            View.IConsoleView view = new View.ConsoleView();
            Controller.Game game = new Controller.Game(view);

            game.run();
        }
    }
}
