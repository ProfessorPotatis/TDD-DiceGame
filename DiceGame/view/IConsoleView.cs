using System;

namespace DiceGame.View
{
    public interface IConsoleView
    {
        void showMenu();
        void showQuitMessage();
        void showBetting();
        bool userQuits();
    }
}