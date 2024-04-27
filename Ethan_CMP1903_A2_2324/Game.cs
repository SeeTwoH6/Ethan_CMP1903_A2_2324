using System;
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
            while (choice != 4)
            {
                choice = 0;
                while (choice < 1 || choice > 4)
                {
                    Console.WriteLine("Select Option Below: \n1) Sevens Out Game\n2) Three or More\n3) How to Play\n4) Exit");
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
                    Console.WriteLine("Play:\n1)Singleplayer?\n2)Two players?");
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
                    stats.Games7Played(sevens.gamesPlayed);
                    stats.HighScore(sevens.playerScore);
                    stats.HighScore(sevens.oppScore);
                    stats.Update7Turns(sevens.turns);
                    stats.UpdateWins(sevens.p1Wins);
                    stats.UpdateWins(sevens.oppWins);
                }
                //Three or More game was selected
                else if (choice == 2)
                {
                    threeOrMore.StartGame(opponent);
                    stats.Games3Played(threeOrMore.gamesPlayed);
                    stats.Update3Turns(threeOrMore.turns);
                    stats.UpdateWins(threeOrMore.p1Wins);
                    stats.UpdateWins(threeOrMore.oppWins);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Sevens Out\r\n2 x dice\r\nRules:\r\n\tRoll the two dice, noting the total rolled each time.\r\n\tIf it is a 7 - stop.\r\n\tIf it is any other number - add it to your total.\r\n\t\tIf it is a double - add double the total to your score (3,3 would add 12 to your total)\r\n\r\nThree or More\r\n5 x dice\r\nRules:\r\n\tRoll all 5 dice hoping for a 3-of-a-kind or better.\r\n\tIf 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.\r\n\t3-of-a-kind: 3 points\r\n\t4-of-a-kind: 6 points\r\n\t5-of-a-kind: 12 points\r\n\tFirst to a total of 20.\r\n");
                }
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}