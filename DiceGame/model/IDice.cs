using System;

namespace DiceGame.Model
{
    public interface IDice
    {
        int rollDice();
        int sumDice(int dice1, int dice2);
    }
}