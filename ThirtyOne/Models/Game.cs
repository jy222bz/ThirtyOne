
using ThirtyOne.Args;

namespace ThirtyOne.Models
{
    public class Game
    {
        private readonly Dice dice = new Dice();
        private int throwCounter = 0;
        private int roundCounter = 0;
        private readonly int[] dices = new int[6];
        private int total = 0;
        private ScoreHandler scoreHandler = new ScoreHandler();


        public bool IsGameOver()
        {
            return roundCounter == 10;
        }

        public void Init()
        {
            throwCounter = 0;
            roundCounter = 0;
            total = 0;
            scoreHandler = new ScoreHandler();
        }

        public bool IsFirstRoll()
        {
            return throwCounter == 1;
        }

        public int[] Play(bool[] isBehold)
        {
            throwCounter++;

            for (int i = 0; i < dices.Length; i++)
            {
                if (!isBehold[i])
                {
                    dices[i] = dice.Roll();
                }
            }

            if (throwCounter == 3)
            {
                ++roundCounter;
            }
            return dices;
        }

        public bool IsRoundOver()
        {
            return throwCounter == 3;
        }

        public void SetRound()
        {
            throwCounter = 0;
        }

        public int GetTotal()
        {
            return total;
        }

        public GameArgs GetScore()
        {
            GameArgs gameArgs = scoreHandler.CountResult(dices);
            gameArgs.RoundNumber = roundCounter;
            total += gameArgs.Total;
            gameArgs.Combination = GetCombination(dices);
            return gameArgs;
        }

        public int GetCurrentRound()
        {
            return roundCounter;
        }

        private string GetCombination(int[] dices)
        {
            string Combination = "(";
            for (int index = 0; index < dices.Length - 1; index++)
            {
                Combination += dices[index] + ", ";
            }
            Combination += dices[5] + ")";
            return Combination;
        }
    }
}
