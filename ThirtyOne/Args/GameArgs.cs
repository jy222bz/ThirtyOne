using System;

namespace ThirtyOne.Args
{
    public class GameArgs : EventArgs
    {
        public GameArgs(int total, string option)
        {
            Total = total;
            Option = option;
        }

        public string Option
        {
            get; set;
        }

        public int Total
        {
            get; set;
        }

        public int RoundNumber
        {
            get; set;
        }

        public string Combination
        {
            get; set;
        }

    }
}

