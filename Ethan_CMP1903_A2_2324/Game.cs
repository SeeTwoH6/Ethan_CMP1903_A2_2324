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
            SevensOut sevensGame = new SevensOut();
            Console.WriteLine($"The total of the game before it starts is {sevensGame.ReturnTotal()}");
            sevensGame.StartGame();
            Console.WriteLine($"The total of the game after it finished is {sevensGame.ReturnTotal()}");
            Console.ReadLine();
        }
    }
}
