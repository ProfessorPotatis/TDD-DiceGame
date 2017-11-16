using System;

namespace DiceGame.Controller
{
    public class Game
    {
        private View.IConsoleView _view;

        public Game(View.IConsoleView view)
        {
            View = view;
        }

        public View.IConsoleView View
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
            View.showQuitMessage();
        }
        
    }
}