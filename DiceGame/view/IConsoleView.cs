using System;

namespace DiceGame.View
{
    public interface IConsoleView
    {
        void showMenu();
        void showQuitMessage();
        void showPlayerPoints(int points);
        void showGameOver();
        void showBetting();
        bool userQuits();
        string getUserBet();
        void showRollMessage();
        void showException(string message);
        void showWinner(bool isWinner);
        void showDiceValues(int[] dice);
    }
}