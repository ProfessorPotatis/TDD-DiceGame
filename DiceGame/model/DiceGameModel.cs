using System;
using System.IO;

namespace DiceGame.Model
{
    public class DiceGameModel : IDiceGameModel
    {
        private IDice _dice1;
        private IDice _dice2;

        public DiceGameModel(IDice dice1, IDice dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public IDice Dice1
        {
            get { return _dice1; }
            set
            {
                _dice1 = value;
            }
        }

        public IDice Dice2
        {
            get { return _dice2; }
            set
            {
                _dice2 = value;
            }
        }

        public int getPlayerPoints()
        {
            return 0;
        }

        public void runGame(string bettedMoney)
        {
            int[] dice = this.rollDice();

            int sumOfDice = sumDice(dice[0], dice[1]);
        }

        public int[] rollDice()
        {
            int d1 = Dice1.rollDice();
            int d2 = Dice2.rollDice();

            int[] dice = {d1, d2};

            return dice;
        }

        public int sumDice(int d1, int d2)
        {
            return d1 + d2;
        }
    }
}