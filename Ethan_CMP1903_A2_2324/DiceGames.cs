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
        private int players;
        private int diceRequired;
        public int score { get; set; }
        public int turns { get; set; }
        public int gamesPlayed { get; set; }

        private List<Die> _DieList = new List<Die>(); //List required mainly for testing purposes as I need access to each dice roll from outside this class
        public List<Die> DieList
        {
            get { return _DieList; }
            set { _DieList = value; }
        }


        public void CreateDice(int players,int diceRequired)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                DieList.Add(die);
                Console.WriteLine($"Added a die to die list");
            }
            Console.WriteLine("End of method");
        }

        public int ReturnScore()
        {
            return score;
        }
    }
}
