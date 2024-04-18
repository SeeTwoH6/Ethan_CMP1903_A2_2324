using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class SevensOut : DiceGames
    {
        private int total = 0;
        public void StartGame()
        {
            DiceGames gameSetup = new DiceGames();
            gameSetup.score = 1;
            while (total != 7)
            {
                foreach(Die die in DieList)
                {
                    int turnRoll = die.RollDice();
                    Console.WriteLine($"You rolled a {turnRoll.Roll}");
                    total += turnRoll;   
                }
                if (total == 7)
                {
                    Console.WriteLine("You rolled a 7! Game Over!");
                    break;
                }
                else if (dice1.Roll == dice2.Roll)
                {
                    gameSetup.score += total * 2;
                }
                else
                {
                    gameSetup.score += total;
                }
                Console.WriteLine($"The current total is {gameSetup.ReturnScore()}");
            }
        }
    }
}
