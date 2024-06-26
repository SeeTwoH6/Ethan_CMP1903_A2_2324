﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class DiceGames
    {
        public int playerScore { get; set; }
        public int oppScore { get; set; }
        public int p1Wins { get; set; }
        public int oppWins { get; set; }
        public int turns { get; set; }
        public int playerID { get; set; }

        /// <summary>
        /// Creates diceRequired Die objects and adds them to a list
        /// </summary>
        /// <param name="diceRequired"></param>
        /// <param name="list"></param>
        public void CreateDice(int diceRequired, List<Die> list)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                list.Add(die);
            }
        }

        /// <summary>
        /// Rerolls each die in the passed in dice list
        /// </summary>
        /// <param name="list"></param>
        public virtual int Reroll(List<Die> list)
        {
            foreach (Die die in list)
            {
                die.RollDice();
                Console.WriteLine($"You rolled a {die.Roll}");
            }
            return 0;
        }

        public int ReturnScore(int score)
        {
            return score;
        }
    }
}
