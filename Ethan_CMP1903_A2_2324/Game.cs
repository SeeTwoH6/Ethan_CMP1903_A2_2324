﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Game
    {
        static void Main(string[] args)
        {
            //Instantiate Classes
            Statistics stats = new Statistics();
            SevensOut sevens = new SevensOut();
            ThreeOrMore threeOrMore = new ThreeOrMore();
            Testing tests = new Testing();

            //Inputs needed for option select
            int choice = 0;
            while (choice != 6)
            {
                choice = 0;
                while (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Select Option Below: \n1) Sevens Out Game\n2) Three or More\n3) How to Play\n4) View Statistics\n5) Run Tests\n6) Exit");
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                //Option to choose type of opponent
                int opponent = 0;
                while ((opponent < 1 || opponent > 2) && choice < 3)
                {
                    Console.WriteLine("Play:\n1) Singleplayer?\n2) Two players?");
                    try
                    {
                        opponent = Int32.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                //Sevens Out game was selected
                if (choice == 1)
                {
                    sevens.StartGame(opponent);
                    stats.Games7Played(1);
                    stats.HighScore(sevens.playerScore);
                    stats.HighScore(sevens.oppScore);
                    stats.Update7Turns(sevens.turns);
                    stats.Update1Wins(sevens.p1Wins);
                    stats.Update2Wins(sevens.oppWins);
                }
                //Three or More game was selected
                else if (choice == 2)
                {
                    threeOrMore.StartGame(opponent, false);
                    stats.Games3Played(1);
                    stats.Update3Turns(threeOrMore.turns);
                    stats.Update1Wins(threeOrMore.p1Wins);
                    stats.Update2Wins(threeOrMore.oppWins);
                }
                //Prints out rules to the player
                else if (choice == 3)
                {
                    Console.WriteLine("Sevens Out\r\n2 x dice\r\nRules:\r\n\tRoll the two dice, noting the total rolled each time.\r\n\tIf it is a 7 - stop.\r\n\tIf it is any other number - add it to your total.\r\n\t\tIf it is a double - add double the total to your score (3,3 would add 12 to your total)\r\n\r\nThree or More\r\n5 x dice\r\nRules:\r\n\tRoll all 5 dice hoping for a 3-of-a-kind or better.\r\n\tIf 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.\r\n\t3-of-a-kind: 3 points\r\n\t4-of-a-kind: 6 points\r\n\t5-of-a-kind: 12 points\r\n\tFirst to a total of 20.\r\n");
                }
                //View Statistics
                else if (choice == 4)
                {
                    int viewStats = 0;
                    while (viewStats < 1 || viewStats > 8)
                    {
                        Console.WriteLine("Select Option Below: \n1) Sevens Out High Score\n2) Sevens Out Games Played\n3) Sevens Out Turns Played\n4) Three Or More Games Played\n5) Three Or More Turns Played\n6) Player 1 Wins\n7) Player 2 Wins\n8) Total Games Played");
                        try
                        {
                            viewStats = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    switch (viewStats)
                    {
                        case 1:
                            Console.WriteLine($"The current high score is {stats.ReturnHighScore()}");
                            break;
                        case 2:
                            Console.WriteLine($"{stats.Return7Games()} Sevens Out games have been played");
                            break;
                        case 3:
                            Console.WriteLine($"{stats.Return7Turns()} Sevens Out turns have been played");
                            break;
                        case 4:
                            Console.WriteLine($"{stats.Return3Games()} Three Or More games have been played");
                            break;
                        case 5:
                            Console.WriteLine($"{stats.Return3Turns()} Three Or More turns have been played");
                            break;
                        case 6:
                            Console.WriteLine($"Player 1 wins: {stats.Return1Wins()}");
                            break;
                        case 7:
                            Console.WriteLine($"Player 2 wins: {stats.Return2Wins()}");
                            break;
                        case 8:
                            Console.WriteLine($"Total Games Played: {stats.ReturnGamesPlayed()}");
                            break;

                    }
                }
                //Runs tests
                else if (choice == 5)
                {
                    tests.CheckGame();
                    tests.CheckRolling7s();
                    tests.ScoreChecking();
                    tests.TestTotalTo20();
                }
                //Exits program
                else if (choice == 6)
                {
                    Console.WriteLine("Thanks for playing!\nPress any key to close");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}