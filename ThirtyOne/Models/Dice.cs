using System;

namespace ThirtyOne.Models
{
    public class Dice
    {
        public int Roll()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
