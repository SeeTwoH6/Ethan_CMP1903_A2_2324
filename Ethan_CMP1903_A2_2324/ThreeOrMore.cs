using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class ThreeOrMore
    {
        private List<Die> DieList = new List<Die>(); //List required mainly for testing purposes as I need access to each dice roll from outside this class
        private int score;

        //Methods
        /// <summary>
        /// Creates an object of class Die adds it to a list
        /// </summary>
        public void CreateDice()
        {
            Die dice = new Die();
            dice.RollDice();
            DieList.Add(dice);
        }

        public void StartGame()
        {
            for (int i = 0; i < 5; i++)
            {
                CreateDice();
            }
            foreach (Die dice in DieList)
            {
                Console.WriteLine($"You rolled a {dice.Roll}");
            }
            for (int i = 1; i < 7; i++)
            {
                var counter = from num in DieList
                              where num.Roll == i
                              select num;
                
                if(counter.Count() == 2)
                {
                    Console.WriteLine("You rolled 2 of a kind, do you want to ");
                    
                }
            }
        }
    }
}
