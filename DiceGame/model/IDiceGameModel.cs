using System;

namespace DiceGame.Model
{
    public interface IDiceGameModel
    {
        void runGame(string bettedMoney);
        void rollDice();
    }
}