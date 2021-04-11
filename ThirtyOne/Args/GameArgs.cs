using System;

namespace ThirtyOne.Args
{
    /// <summary>
    /// This is a class for the game arguments.
    /// Author: Jacob Yousif
    /// </summary>
    public class GameArgs : EventArgs
    {
        /// <summary>
        /// A public constructor.
        /// </summary>
        /// <param name="total">The total points gained during one round of the game.</param>
        /// <param name="option">The option was chosen for the calculation.</param>
        public GameArgs(int total, string option)
        {
            Total = total;
            Option = option;
        }

        /// <summary>
        /// A property for the option.
        /// </summary>
        public string Option
        {
            get; set;
        }

        /// <summary>
        /// A property for the points.
        /// </summary>
        public int Total
        {
            get; set;
        }

        /// <summary>
        /// A property for the round number.
        /// </summary>
        public int RoundNumber
        {
            get; set;
        }

        /// <summary>
        /// A property for the combination of the dices.
        /// </summary>
        public string Combination
        {
            get; set;
        }

    }
}

