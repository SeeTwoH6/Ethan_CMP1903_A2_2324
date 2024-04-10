using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Game
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("Play against:\n1)A Player?\n2)An AI?");
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
                SevensOut player1 = new SevensOut();
                player1.StartGame();
                Console.WriteLine($"Player 1 got a score of {player1.ReturnTotal()}");

                SevensOut player2 = new SevensOut();
                player2.StartGame();
                Console.WriteLine($"Player 2 got a score of {player2.ReturnTotal()}");
            }
            //Three or More game was selected
            else if(choice == 2)
            {
                ThreeOrMore player1 = new ThreeOrMore();
                player1.StartGame();
            }
            Console.ReadLine();
        }
    }
}