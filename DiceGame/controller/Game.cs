using System;

namespace DiceGame.Controller
{
    public class Game
    {
        private View.ConsoleView _view;

        public Game(View.ConsoleView view)
        {
            View = view;
        }

        public View.ConsoleView View
        {
            get { return _view; }
            set
            {
                _view = value;
            }
        }

        public void run()
        {
            View.showMenu();
        }
        
    }
}