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
        public void StartGame()
        {
            int total = 0;
            score = 0;
            turns = 0;
            var firstDice = DieList.First();
            var secondDice = DieList.Last();
            gamesPlayed++;
            while (total != 7)
            {
                total = 0;
                turns++;
                foreach(Die die in DieList)
                {
                    int turnRoll = die.RollDice();
                    Console.WriteLine($"You rolled a {die.Roll}");
                    total += turnRoll;   
                }
                if (total == 7)
                {
                    Console.WriteLine("You rolled a 7! Game Over!");
                    break;
                }
                else if (firstDice.Roll == secondDice.Roll)
                {
                    score += total * 2;
                }
                else
                {
                    score += total;
                }
                Console.WriteLine($"Your current score is {ReturnScore()}");
            }
            Console.WriteLine($"Your final score is {ReturnScore()}");
        }
    }
}
