using System;
using System.IO;
using System.Text.RegularExpressions;

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
            if (Regex.IsMatch(bet, @"^\d+$"))
            {
                int theBet = int.Parse(bet);
                int points = this.getPlayerPoints();

                if (theBet > points)
                {
                    throw new ArgumentOutOfRangeException("", "\nBet is out of range.");
                }
                return true;
            } else
            {
                throw new FormatException("Bet must be in the form of a number.");
            }
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