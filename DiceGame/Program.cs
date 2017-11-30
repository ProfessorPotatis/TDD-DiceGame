using System;
using System.IO;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            View.IConsoleView view = new View.ConsoleView();
            Model.IDice dice1 = new Model.Dice();
            Model.IDice dice2 = new Model.Dice();
            Model.IPlayer player = new Model.Player();
            Model.IDiceGameModel model = new Model.DiceGameModel(dice1, dice2, player);
            Controller.Game game = new Controller.Game(view, model);

            game.run();
        }
    }
}
