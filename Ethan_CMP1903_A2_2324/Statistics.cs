using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Statistics
    {
        public int high7Score { get; set; }

        public Statistics() 
        {
            high7Score = 0;
        }
        public int ReturnHigh7Score()
        {
            return high7Score;
        }
        public void High7Score(int score)
        {
            if (score > high7Score)
            {
                high7Score = score;
            }
            Console.WriteLine($"Record high score is {high7Score}");
        }
    }
}
