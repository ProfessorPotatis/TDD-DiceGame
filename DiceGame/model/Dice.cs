using System;
using System.IO;

namespace DiceGame.Model
{
    public class Dice : IDice
    {
        private Random _die;

        public Dice()
        {
            Die = new Random();
        }

        public Random Die
        {
            get { return _die; }
            set
            {
                _die = value;
            }
        }

        public int rollDice()
        {
            return Die.Next(1, 7);;
        }

        public int sumDice(int d1, int d2)
        {
            return d1 + d2;
        }
    }
}