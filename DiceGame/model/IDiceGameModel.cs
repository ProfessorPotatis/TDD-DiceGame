using System;

namespace DiceGame.Model
{
    public interface IDiceGameModel
    {
        void runGame(string bettedMoney);
        int[] rollDice();
        int sumDice(int dice1, int dice2);
    }
}