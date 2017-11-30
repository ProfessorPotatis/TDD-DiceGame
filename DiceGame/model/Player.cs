using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DiceGame.Model
{
    public class Player : IPlayer
    {
        private const int STARTING_POINTS = 100;
        private const string BET_OUT_OF_RANGE = "\nBet is out of range.";
        private const string BET_NUMBER = "Bet must be in the form of a number.";
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

        public bool isPointsZero()
        {
            throw new NotImplementedException();
        }

        public bool checkBetting(string bet)
        {
            bool isNumber = this.checkIfNumber(bet);
            int theBet = this.parseToInt(bet);
            int points = this.getPlayerPoints();

            if (theBet > points)
            {
                throw new ArgumentOutOfRangeException("", BET_OUT_OF_RANGE);
            }
            return true;
        }

        public bool checkIfNumber(string bet)
        {
            if (Regex.IsMatch(bet, @"^\d+$"))
            {
                return true;
            } else
            {
                throw new FormatException(BET_NUMBER);
            }
        }

        public int parseToInt(string bet)
        {
            return int.Parse(bet);
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