using System;
using System.IO;

namespace DiceGame.Model
{
    public class Player : IPlayer
    {
        private const int STARTING_POINTS = 100;
        private int _points;

        public Player()
        {
            Points = STARTING_POINTS;
        }

        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
            }
        }

        public int getPlayerPoints()
        {
            return Points;
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

        public void addPoints(int plusPoints)
        {
            Points += plusPoints;
        }

        public void removePoints(int minusPoints)
        {
            Points -= minusPoints;
        }
    }
}