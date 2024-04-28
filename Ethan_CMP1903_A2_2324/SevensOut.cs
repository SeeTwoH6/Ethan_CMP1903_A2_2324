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
        public bool TestRoll()
        {
            int sum = 0;
            List<Die> testDice = new List<Die>
            {
                new Die(),
                new Die()
            };
            while (sum != 7)
            {
                Console.WriteLine("Testing next dice roll turn...");
                sum = 0;
                foreach (Die die in testDice)
                {
                    int turnRoll = die.RollDice();
                    Console.WriteLine($"Test dice rolled a {die.Roll}");
                    sum += turnRoll;
                }
            }
            Console.WriteLine("A 7 has been rolled, stopping the rolling process");
            return true;
        }
        public void StartGame(int players)
        {
            //Game setup
            playerScore = 0;
            oppScore = 0;
            List<Die> gameDice = new List<Die>();
            CreateDice(2, gameDice);
            var firstDice = gameDice.First();
            var secondDice = gameDice.Last();
            for (int i = 0; i < players; i++)
            {
                Console.WriteLine($"Player {i+1}:\n");
                int sum = 0;
                turns = 0;
                while (sum != 7)
                {
                    turns++;
                    sum = 0;

                    if (i == 0 || (players == 2 && i == 1))
                    {
                        Console.WriteLine("Press any key to roll your dice");
                        var rollingDice = Console.ReadKey();
                    }
                    foreach (Die die in gameDice)
                    {
                        int turnRoll = die.RollDice();
                        Console.WriteLine($"You rolled a {die.Roll}");
                        sum += turnRoll;
                    }
                    if (sum == 7)
                    {
                        Console.WriteLine("You rolled a 7! Game over!");
                    }
                    else if (firstDice.Roll == secondDice.Roll)
                    {
                        Console.WriteLine("You rolled a double!");
                        if (i == 0) //Player 1
                        {
                            playerScore += sum * 2;
                        }
                        else if (i == 1) //Player 2
                        {
                            oppScore += sum * 2;
                        }
                    }
                    else
                    {
                        if (i == 0) //Player 1
                        {
                            playerScore += sum;
                        }
                        else if (i == 1) //Player 2
                        {
                            oppScore += sum;
                        }
                    }
                    if (i == 0) //P1
                    {
                        Console.WriteLine($"\nYour current score is {playerScore}");
                    }
                    else if (i == 1) //P2
                    {
                        Console.WriteLine($"\nYour current score is {oppScore}");
                    }

                }
                if (i == 0) //P1
                {
                    Console.WriteLine($"\nYour final score is {playerScore}\n");
                }
                else if (i == 1) //P2
                {
                    Console.WriteLine($"\nYour final score is {oppScore}\n");
                }
            }
            //Announcing Winner
            if (players > 1)//Only need to run this loop if there is more than 1 player
            {
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
}
