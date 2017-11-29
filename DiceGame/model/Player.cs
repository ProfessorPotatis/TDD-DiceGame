using System;
using System.IO;

namespace DiceGame.Model
{
    public class Player : IPlayer
    {
        private int points;

        public Player()
        {
            points = 100;
        }

        public int getPlayerPoints()
        {
            return points;
        }

        public bool checkBetting(string bet)
        {
            int theBet = int.Parse(bet);
            int points = this.getPlayerPoints();

            if (theBet > points)
            {
                throw new ArgumentOutOfRangeException("", "\nBet is out of range.");
            }
            return true;
        }
    }
}