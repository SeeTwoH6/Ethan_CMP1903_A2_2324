using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class SevensOut
    {
        Die dice1 = new Die();
        Die dice2 = new Die();

        int total = 0;
        int sum = 0;
        public void StartGame()
        {
            while(sum != 7)
            {
                dice1.RollDice();
                dice2.RollDice();
                sum = dice1.Roll + dice2.Roll;
                Console.WriteLine($"The first dice rolled a {dice1.Roll}");
                Console.WriteLine($"The second dice rolled a {dice2.Roll}");
                if (sum == 7)
                {
                    Console.WriteLine("You rolled a 7! Game Over!");
                    break;
                }
                else if (dice1.Roll == dice2.Roll)
                {
                    total += sum * 2;
                }
                else
                {
                    total += sum;
                }
                Console.WriteLine($"The current total is {total}");
            }
        }

        public int ReturnTotal()
        {
            return total;
        }
    }
}
