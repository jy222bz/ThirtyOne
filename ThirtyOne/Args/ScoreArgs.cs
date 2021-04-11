using System;

namespace ThirtyOne.Args
{
    /// <summary>
    /// This is a class for scores of the entire game.
    /// It implements the IComparable<ScoreArgs> in order to sort the objects.
    /// Author: Jacob Yousif
    /// </summary>
    [Serializable]
    public class ScoreArgs : EventArgs, IComparable<ScoreArgs>
    {
        /// <summary>
        /// A paramterless constructor.
        /// </summary>
        public ScoreArgs()
        {
        }


        /// <summary>
        /// A public constructor.
        /// </summary>
        /// <param name="username">The player username.</param>
        /// <param name="score">The total score of points that were gained in the game.</param>
        public ScoreArgs(string username, int score)
        {
            Score = score;
            Username = username;
        }


        /// <summary>
        /// A property for the username.
        /// </summary>
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// A property for the score.
        /// </summary>
        public int Score
        {
            get; set;
        }

        /// <summary>
        /// It compares the objects in decending order.
        /// </summary>
        /// <param name="other">The other object that will be compared with this object.</param>
        /// <returns>The comparsion result.</returns>
        public int CompareTo(ScoreArgs other)
        {
            return other.Score.CompareTo(Score);
        }
    }
}
