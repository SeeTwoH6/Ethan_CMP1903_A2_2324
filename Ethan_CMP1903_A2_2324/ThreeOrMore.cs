using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class ThreeOrMore : DiceGames
    {
        public override void CreateDice(int diceRequired)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                die.RollDice();
                DieList.Add(die);
                Console.WriteLine($"You rolled a {die.Roll}");
            }
            Console.WriteLine("End of method");
        }
        public void StartGame()
        {
            for (int i = 6; i >= 1 ; i--) //1-6 represents each possibility of dice rolls, starting of 6 because we're hoping to catch the highest duplicates first
            {
                List<int> listOfIndices = new List<int>();
                int count = 0;
                int index = 0;
                foreach (Die die in DieList) //Iterating through each dice in the list
                {
                    if (i == die.Roll) //If the current dice number (i) is the same as the currently inspected die in list (die.Roll)
                    {
                        count++;
                        if (listOfIndices.Count < 2)
                        {
                            listOfIndices.Add(index);
                        }
                    }
                    index++;
                }
                if (count >= 2)
                {
                    Console.WriteLine($"You rolled at least two {i}'s\nDo you want to:\n1) Reroll the rest of your dice?\n2) Reroll all of your dice\n3)Proceed with point calculation");
                }
                //Reroll the rest of the dice
                index = 0;
                foreach (Die die in DieList) //Go through each dice in the list again
                {
                    if (index != listOfIndices.First() || index != listOfIndices.Last()) //If the current index is not any of the two items in the list (items in the list are there 2 of a kind)
                    {
                        die.RollDice();
                    }
                    index++;
                }
                //Reroll all dice
                foreach (Die die in DieList)
                {
                    die.RollDice();
                }
            }
        }
    }
}
