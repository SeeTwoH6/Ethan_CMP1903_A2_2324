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
            Statistics stats = new Statistics();
            //Inputs needed for option select
            int choice = 0;
            while (choice < 1 || choice > 4)
            {
                Console.WriteLine("Select Option Below: \n1) Sevens Out Game\n2) Three or More\n3) How to Play\n4) Exit");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Option to choose type of opponent
            int opponent = 0;
            while (opponent < 1 || opponent > 2)
            {
                Console.WriteLine("Play against:\n1)An AI?\n2)A Player?");
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
                int hiScore = 0;
                int winner = 0;
                for (int i = 1; i <= opponent; i++)
                {
                    Console.WriteLine($"Player {i}:");
                    SevensOut player = new SevensOut();
                    player.StartGame();
                    if (player.ReturnScore() > hiScore)
                    {
                        hiScore = player.ReturnScore();
                        winner = i;
                    }
                    stats.High7Score(player.ReturnScore());
                }
                if (winner > 0) //There is a definite winner
                {
                    Console.WriteLine($"Winner is player {winner} with a score of {hiScore}");
                }
                else if (winner == 0)
                {
                    Console.WriteLine($"Tied game of {hiScore}");
                }
            }
            //Three or More game was selected
            else if (choice == 2)
            {
                ThreeOrMore player = new ThreeOrMore();
                player.StartGame(opponent);
            }
            Console.ReadLine();
        }
    }
}