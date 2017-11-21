using System;
using System.IO;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter stringWriter = new StringWriter();
            StringReader stringReader = new StringReader(Console.ReadLine());
            View.IConsoleView view = new View.ConsoleView(stringWriter, stringReader);
            Model.IDiceGameModel model = new Model.DiceGameModel();
            Controller.Game game = new Controller.Game(view, model);

            game.run();
        }
    }
}
