using System;

namespace ThirtyOne.Models
{
    /// <summary>
    /// This is a class for the dice object.
    /// Author: Jacob Yousif
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// A private field for the random object.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// It returns a random value between 1 and 6.
        /// </summary>
        /// <returns>Random integer.</returns>
        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}
