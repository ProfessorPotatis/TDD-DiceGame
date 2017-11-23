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

    }
}