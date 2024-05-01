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
            Console.WriteLine("Testing instantiation of the Game object");
            Game testGame = new Game();
            Debug.Assert(testGame != null, "Game object is null");
            Console.WriteLine("Game object successfully created");
        }

        //Sevens Out: Total of sum, stop if total = 7
        public void CheckRolling7s()
        {
            Console.WriteLine("Testing if dice will stop rolling if the sum == 7");
            SevensOut testSevens = new SevensOut();
            bool working = false; //Assume system does not initially work as intended
            working = testSevens.TestRoll();
            //Use debug.assert() to verify:
            Debug.Assert(working, "Rolling dice not functioning as required");
            Console.WriteLine("Sevens Out stops if a seven is rolled");
        }

        //Three Or More: Scores set and added correctly, recognise when total >= 20.
        public void ScoreChecking()
        {
            Console.WriteLine("Checking if scores are set and added correctly");
            ThreeOrMore testThree = new ThreeOrMore();
            testThree.StartGame(1, true);
        }
        public void TestTotalTo20()
        {
            int scoreToTest = 0;
            Console.WriteLine("Creating a test game to check if score will correctly stop when total >= 20");
            ThreeOrMore testThree = new ThreeOrMore();
            testThree.StartGame(1, false);
            scoreToTest = testThree.playerScore > testThree.oppScore ? testThree.playerScore : testThree.oppScore;
            Debug.Assert(scoreToTest >= 20, "Winning score is less than 20 so an error has occurred");
            Console.WriteLine("Points totalled to an acceptable value");
        }
    }
}
