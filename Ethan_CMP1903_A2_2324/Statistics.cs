using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethan_CMP1903_A2_2324
{
    internal class Statistics
    {
        public Statistics()
        {
            highScore = 0;
            games7Played = 0;
            games3Played = 0;
            turns7 = 0;
            turns3 = 0;
            wins1 = 0;
            wins2 = 0;
        }

        //High Score
        private int highScore { get; set; }

        public int ReturnHighScore()
        {
            return highScore;
        }
        public void HighScore(int score)
        {
            if (score > highScore)
            {
                highScore = score;
            }
        }

        //Games Played - 7s out
        private int games7Played { get; set; }
        public void Games7Played(int rounds)
        {
            games7Played += rounds;
        }
        public int Return7Games()
        {
            return games7Played;
        }

        //Games Played - 3OrMore
        private int games3Played { get; set; }
        public void Games3Played(int rounds)
        {
            games3Played += rounds;
        }
        public int Return3Games()
        {
            return games3Played;
        }

        //Turns - 7s Out
        private int turns7 { get; set; }
        public void Update7Turns(int turnsPlayed)
        {
            turns7 += turnsPlayed;
        }

        public int Return7Turns()
        {
            return turns7;
        }

        //Turns - 3OrMore
        private int turns3 { get; set; }
        public void Update3Turns(int turnsPlayed)
        {
            turns3 += turnsPlayed;
        }

        public int Return3Turns()
        {
            return turns3;
        }

        //Wins - P1
        private int wins1 { get; set; }
        public void Update1Wins(int wins)
        {
            wins1 += wins;
        }
        public int Return1Wins()
        {
            return wins1;
        }

        //Wins - P2
        private int wins2 { get; set; }
        public void Update2Wins(int wins)
        {
            wins2 += wins;
        }
        public int Return2Wins()
        {
            return wins2;
        }

        public int ReturnGamesPlayed()
        {
            return games7Played + games3Played;
        }
    }
}
