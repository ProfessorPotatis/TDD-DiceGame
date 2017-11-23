using System;
using System.IO;

namespace DiceGame.Model
{
    public class Player : IPlayer
    {
        public int getPlayerPoints()
        {
            return 100;
        }

        public bool checkBetting(string bet)
        {
            return false;
        }
    }
}