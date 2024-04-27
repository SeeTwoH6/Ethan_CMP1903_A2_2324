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
        public int turns { get; set; }
        public int gamesPlayed { get; set; }
        public int playerID { get; set; }

        public void CreateDice(int diceRequired, List<Die> list)
        {
            for (int i = 0; i < diceRequired; i++)
            {
                Die die = new Die();
                list.Add(die);
            }
            Console.WriteLine($"Starting game with {diceRequired} die\n");
        }

        public virtual void Reroll(List<Die> list)
        {
            foreach (Die die in list)
            {
                die.RollDice();
                Console.WriteLine($"You rolled a {die.Roll}");
            }
        }

        public int ReturnGamesPlayed()
        {
            return gamesPlayed;
        }
    }
}
