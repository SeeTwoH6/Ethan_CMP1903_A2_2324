using System;

namespace Ethan_CMP1903_A2_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */
        //Property
        public int Roll { get; protected set; }
        //Method
        private static Random roll = new Random();

        /// <summary>
        /// Rolls a random number between 1 and 6 inclusively
        /// </summary>
        /// <returns>Returns a single integer</returns>
        public int RollDice()
        {
            Roll = roll.Next(1, 6);
            return Roll;
        }
    }
}