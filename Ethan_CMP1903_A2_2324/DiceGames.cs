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
        public int score { get; set; }
        public int turns { get; set; }
        public int gamesPlayed { get; set; }

        public virtual void CreateDice(int diceRequired, List<Die> list)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                list.Add(die);
                Console.WriteLine($"Added a die to die list");
            }
            Console.WriteLine("End of method");
        }

        public void Reroll(List<Die> list)
        {
            foreach (Die die in list)
            {
                die.RollDice();
                Console.WriteLine($"You rolled a {die.Roll}");
            }
        }

        public int ReturnScore()
        {
            return score;
        }
        public int ReturnGamesPlayed()
        {
            return gamesPlayed;
        }
    }
}
