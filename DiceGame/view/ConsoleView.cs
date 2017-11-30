using System;
using System.IO;
using System.Threading;

namespace DiceGame.View
{
    public class ConsoleView : IConsoleView
    {
        public const string MENU = "Dice Game Menu\nPress any key to play or 'q' to quit.";
        public const string QUIT = "Thank you for playing and welcome back next time.";
        public const string BET = "Place your bet: ";
        public const string QUIT_OPTION = "q";
        public const string YOU_BET = "\nYou bet: ";
        public const string ROLL = "\nRolling the dice...";
        public const string WINNER = "\nYou are a winner!\nPress any key to play again or 'q' to quit";
        public const string LOSER = "\nYou lost.\nPress any key to play again or 'q' to quit";
        public const string GAME_OVER = "GAME OVER!";


        public void showMenu()
        {
            Console.WriteLine(MENU);
        }

        public void showQuitMessage()
        {
            Console.WriteLine(QUIT);
        }

        public void showPlayerPoints(int points)
        {
            Console.Clear();
            Console.WriteLine("Player has {0} points.", points);
        }

        public void showGameOver()
        {
            Console.WriteLine(GAME_OVER);
        }

        public void showBetting()
        {
            Console.WriteLine(BET);
        }

        public bool userQuits()
        {
            string quit = Console.ReadLine();

            if (quit == QUIT_OPTION)
            {
                return true;
            }
            return false;
        }

        public string getUserBet()
        {
            string bet = Console.ReadLine();
            Console.WriteLine(YOU_BET + "{0}", bet);
            return bet;
        }

        public void showRollMessage()
        {
            Console.WriteLine(ROLL);
        }

        public void showException(string message)
        {
            Console.WriteLine(message);
        }

        public void showWinner(bool isWinner)
        {
            if (isWinner)
            {
                Console.WriteLine(WINNER);
            } else
            {
                Console.WriteLine(LOSER);
            }
        }

        public void showDiceValues(int[] dice)
        {
            Thread.Sleep(1500);
            Console.WriteLine("\nDice 1: {0}", dice[0]);
            Thread.Sleep(1500);
            Console.WriteLine("Dice 2: {0}", dice[1]);
        }
    }
}