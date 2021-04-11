using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirtyOne.Args
{
    [Serializable]
    public class ScoreArgs : EventArgs, IComparable<ScoreArgs>
    {
        public ScoreArgs()
        {
        }


        public ScoreArgs(string username, int score)
        {
            Score = score;
            Username = username;
        }


        public string Username
        {
            get; set;
        }

        public int Score
        {
            get; set;
        }

        public int CompareTo(ScoreArgs other)
        {
            return other.Score.CompareTo(Score);
        }
    }
}
