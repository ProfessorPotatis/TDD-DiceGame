using System;

namespace DiceGame.Model
{
    public interface IPlayer
    {
        int getPlayerPoints();
        bool checkBetting(string bet);
    }
}