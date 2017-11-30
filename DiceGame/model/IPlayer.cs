using System;

namespace DiceGame.Model
{
    public interface IPlayer
    {
        int getPlayerPoints();
        bool checkBetting(string bet);
        bool checkIfNumber(string bet);
        int parseToInt(string bet);
        void addPoints(int plusPoints);
        void removePoints(int minusPoints);
    }
}