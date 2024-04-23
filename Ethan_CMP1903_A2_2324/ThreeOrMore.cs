using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ethan_CMP1903_A2_2324
{
    internal class ThreeOrMore : DiceGames
    {
        public ThreeOrMore() 
        {
            gamesPlayed = 0;
            score = 0;
            turns = 0;
        }
        public override void CreateDice(int diceRequired, List<Die> list)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                die.RollDice();
                list.Add(die);
                Console.WriteLine($"You rolled a {die.Roll}");
            }
            Console.WriteLine("End of method");
        }
        public void StartGame(int players)
        {
            //Game setup
            gamesPlayed++;
            turns = 0;
            int playerScore = 0;
            int oppScore = 0;
            int playerID = 0;
            List<Die> playerDice = new List<Die>();
            List<Die> oppDice = new List<Die>();
            List<Die> dieList = new List<Die>();
            if (players == 1)
            {
                Console.WriteLine("Creating dice for 1 player");
                CreateDice(5, playerDice);
            }
            else if (players == 2)
            {
                Console.WriteLine("Creating dice for 2 players");
                CreateDice(5, playerDice);
                CreateDice(5, oppDice);
            }

            //Game
            while (playerScore < 20 || oppScore < 20)
            {
                if (players == 1)
                {
                    playerID = 0;
                }
                else if (players == 2)
                {
                    playerID = turns % 2;
                }
                turns++;

                if (playerID == 0)
                {
                    dieList = playerDice;
                }
                else if (playerID == 1)
                {
                    dieList = oppDice;
                }

                for (int i = 6; i >= 1; i--) //1-6 represents each possibility of dice rolls, starting of 6 because we're hoping to catch the highest duplicates first
                {
                    List<int> listOfIndices = new List<int>();
                    int count = 0;
                    int index = 0;
                    foreach (Die die in dieList) //Iterating through each dice in the list
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

                    int choice = 0;
                    if (count >= 2)
                    {
                        while (choice < 1 || choice > 3)
                        {
                            Console.WriteLine($"You rolled at least two {i}'s\nDo you want to:\n1) Reroll the rest of your dice?\n2) Reroll all of your dice\n3)Proceed with point calculation");
                            try
                            {
                                choice = Int32.Parse(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                    if (choice == 1)
                    {
                        //Reroll the rest of the dice
                        index = 0;
                        foreach (Die die in dieList) //Go through each dice in the list again
                        {
                            if (index != listOfIndices.First() || index != listOfIndices.Last()) //If the current index is not any of the two items in the list (items in the list are the 2 of a kind)
                            {
                                die.RollDice();
                            }
                            index++;
                        }
                    }

                    else if (choice == 2)
                    {
                        //Reroll all dice
                        foreach (Die die in dieList)
                        {
                            die.RollDice();
                        }
                    }

                    else if (choice == 3)//Point calculation
                    {
                        foreach (Die die in dieList)
                        {
                            if (playerID == 0)
                            {
                                playerScore += die.Roll;
                            }
                            else if (playerID == 1)
                            {
                                oppScore += die.Roll;
                            }
                        }
                    }

                }
            }
        }
    }
}