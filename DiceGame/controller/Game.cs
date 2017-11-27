using System;

namespace DiceGame.Controller
{
    public class Game
    {
        private View.IConsoleView _view;
        private Model.IDiceGameModel _model;

        public Game(View.IConsoleView view, Model.IDiceGameModel model)
        {
            View = view;
            Model = model;
        }

        public View.IConsoleView View
        {
            get { return _view; }
            set
            {
                _view = value;
            }
        }

        public Model.IDiceGameModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }

        public void run()
        {
            try
            {
                View.showMenu();

                if (View.userQuits() == false)
                {
                    int points = Model.getPlayerPoints();

                    View.showPlayerPoints(points);

                    View.showBetting();

                    string bet = View.getUserBet();

                    View.showRollMessage();

                    Model.runGame(bet);
                }

                View.showQuitMessage();
            } catch (Exception ex)
            {
                View.showException(ex.Message);
            }
        }
        
    }
}