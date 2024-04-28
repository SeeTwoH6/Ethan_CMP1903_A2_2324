using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Testing
    {
        public void CheckGame()
        {
            //Create a Game object
            Game testGame = new Game();
            Debug.Assert(testGame != null, "Game object is null");
            Console.WriteLine("Game object successfully created");
        }

        //Sevens Out: Total of sum, stop if total = 7
        public void CheckRolling7s()
        {
            SevensOut testSevens = new SevensOut();
            bool working = false; //Assume system does not initially work as intended
            working = testSevens.TestRoll();
            //Use debug.assert() to verify:
            Debug.Assert(working, "Rolling dice not functioning as required");
            Console.WriteLine("Sevens Out stops if a seven is rolled");
        }

        //Three Or More: Scores set and added correctly, recognise when total >= 20.
        
    }
}
