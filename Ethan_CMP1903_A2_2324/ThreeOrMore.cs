using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }

        public void Reroll(List<Die> list, int repeatValue)
        {
            int skipReroll = 0; //Used to count how many times a reroll doesnt happen
            foreach (Die die in list)
            {
                //Conditional checks if the dice roll is not the repeated value or the number of times a reroll has been skipped is greater than 1 
                //skipReroll allows for only 2 copies of a number to be rerolled
                //If user rolls 3 of a kind and chooses to reroll remaining dice, then only two of the kind will remain and the third will be rerolled
                if (die.Roll != repeatValue || skipReroll > 1)
                {
                    die.RollDice();
                }
                else
                {
                    skipReroll++;
                }
            }
        }
        public void StartGame(int players)
        {
            //Game setup
            gamesPlayed++;
            playerScore = 0;
            oppScore = 0;
            turns = 0;
            playerID = 0;
            List<Die> playerDice = new List<Die>();
            List<Die> oppDice = new List<Die>();
            List<Die> dieList = new List<Die>();

            Console.WriteLine("Creating dice for players");
            CreateDice(5, playerDice);
            CreateDice(5, oppDice);

            //Game
            while (playerScore < 20 && oppScore < 20)
            {
                //Calculcate which player is playing
                playerID = turns % 2;
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
                    int repeated = 0;
                    int count = 0;
                    foreach (Die die in dieList) //Iterating through each dice in the list
                    {
                        if (i == die.Roll) //If the current dice number (i) is the same as the currently inspected die in list (die.Roll)
                        {
                            count++;
                            if (count >= 1) //Stores a singular repeated value
                            {
                                repeated = i;
                            }
                        }
                    }

                    int choice = 0;
                    if (count >= 2)
                    {
                        while (choice < 1 || choice > 3)
                        {
                            Console.WriteLine($"\nYou rolled at least two {i}'s\nDo you want to:\n1) Reroll the rest of your dice?\n2) Reroll all of your dice\n3)Proceed with point calculation\n");
                            if (players == 2 || (players == 1 && playerID == 0))
                            {
                                try
                                {
                                    choice = Int32.Parse(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else if (players == 1 && playerID == 1)
                            {
                                //This is the computer picking an option
                                Random AI = new Random();
                                choice = AI.Next(1,3);
                            }
                        }
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nSelected option is to reroll the rest of the dice\n");
                            break;
                        case 2:
                            Console.WriteLine("\nSelected option is to reroll all dice\n");
                            break;
                        case 3:
                            Console.WriteLine("\nSelected option is to head into point calculation\n");
                            break;
                    }

                    if (choice == 1)
                    {
                        //Reroll all the dice besides the two of a kind
                        Reroll(dieList, repeated);
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
            if (playerScore > oppScore)
            {
                Console.WriteLine("Player 1 won!");
                p1Wins++;
            }
            else
            {
                Console.WriteLine("Player 2 won!");
                oppWins++;
            }
        }
    }
}