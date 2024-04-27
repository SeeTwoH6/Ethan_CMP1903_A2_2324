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
            while (playerScore < 20 && oppScore < 20)
            {
                //Calculcate which player is playing
                if (players == 1)
                {
                    playerID = 0;
                }
                else if (players == 2)
                {
                    playerID = turns % 2;
                }
                turns++;

                //Select correct dice list depending on player
                if (playerID == 0)
                {
                    dieList = playerDice;
                }
                else if (playerID == 1)
                {
                    dieList = oppDice;
                }

                Console.WriteLine($"Turn: Player {playerID+1}\n");
                Reroll(dieList);
                for (int i = 1; i <= 6; i++) //1-6 represents each possibility of dice rolls
                {
                    List<int> repeated = new List<int>();
                    int count = 0;
                    foreach (Die die in dieList) //Iterating through each dice in the list
                    {
                        if (i == die.Roll) //If the current dice number (i) is the same as the currently inspected die in list (die.Roll)
                        {
                            count++;
                            if (repeated.Count < 1 && count >= 1) //Stores a singular repeated value
                            {
                                repeated.Add(i);
                            }
                        }
                    }

                    int choice = 0;
                    if (count >= 2)
                    {
                        while (choice < 1 || choice > 3)
                        {
                            Console.WriteLine($"\nYou rolled at least two {i}'s\nDo you want to:\n1) Reroll the rest of your dice?\n2) Reroll all of your dice\n3)Proceed with point calculation");
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
                        int skipReroll = 0;
                        foreach (Die die in dieList) //Go through each dice in the list again
                        {
                            //I need to count how many times a reroll doesnt happen
                            if (die.Roll != repeated.First() || skipReroll > 1) //If the current index is not any of the two items in the list (items in the list are the 2 of a kind)
                            {
                                die.RollDice();
                            }
                            else
                            {
                                skipReroll++;
                            }
                        }
                        break;
                    }

                    else if (choice == 2)
                    {
                        //Reroll all dice
                        Reroll(dieList);
                        break;
                    }

                    else if (choice == 3)//Point calculation
                    {
                        break;
                    }
                }

                //Calculating score
                Console.WriteLine("\nPoints are about to be calculated...");
                foreach (Die die in dieList)
                {
                    Console.WriteLine($"You rolled a {die.Roll}");
                }
                for (int i = 1; i <= 6; i++)
                {
                    int count = 0;
                    int points = 0;
                    foreach (Die die in dieList)
                    {
                        if (die.Roll == i)
                        {
                            count++;
                        }
                    }

                    if (count == 3)
                    {
                        points += 3;
                        Console.WriteLine("\nYou rolled 3 of a kind!");
                    }
                    else if (count == 4)
                    {
                        points += 4;
                        Console.WriteLine("\nYou rolled 4 of a kind!");
                    }
                    else if (count == 5)
                    {
                        points += 5;
                        Console.WriteLine("\nYou rolled 5 of a kind!");
                    }

                    if (playerID == 0)
                    {
                        playerScore += points;
                    }
                    else if (playerID == 1)
                    {
                        oppScore += points;
                    }
                }
                Console.WriteLine($"\nPlayer 1 Score: {playerScore}");
                Console.WriteLine($"Player 2 Score: {oppScore}\n");
            }

            Console.WriteLine("Game Over!");
        }
    }
}