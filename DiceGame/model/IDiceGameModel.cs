using System;

namespace DiceGame.Model
{
    public interface IDiceGameModel
    {
        int getPlayerPoints();
        bool checkBetting(string bet);
        int[] rollDice();
        int sumDice(int dice1, int dice2);
        bool isWinner(int sum);
    }
}