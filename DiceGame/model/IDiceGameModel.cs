using System;

namespace DiceGame.Model
{
    public interface IDiceGameModel
    {
        int getPlayerPoints();
        void runGame(string bettedMoney);
        bool checkBetting(string bet);
        int[] rollDice();
        int sumDice(int dice1, int dice2);
    }
}