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
            Model.IDice dice1 = new Model.Dice();
            Model.IDice dice2 = new Model.Dice();
            Model.IDiceGameModel model = new Model.DiceGameModel(dice1, dice2);
            Controller.Game game = new Controller.Game(view, model);

            game.run();
        }
    }
}
