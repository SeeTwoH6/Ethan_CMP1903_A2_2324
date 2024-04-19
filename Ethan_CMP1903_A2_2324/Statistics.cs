using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Statistics
    {
        public void HighScore(int score, int prevMax)
        {
            if (score > prevMax)
            {
                prevMax = score;
            }
        }
    }
}
