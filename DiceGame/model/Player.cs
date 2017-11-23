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
            int theBet = int.Parse(bet);
            int points = this.getPlayerPoints();

            if (theBet > points)
            {
                return false;
            }
            return true;
        }
    }
}