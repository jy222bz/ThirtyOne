using ThirtyOne.Args;

namespace ThirtyOne.Models
{
    /// <summary>
    /// This is a class for the game object.
    /// Author: Jacob Yousif
    /// </summary>
    public class Game
    {
        /// <summary>
        /// A private field for the dice.
        /// </summary>
        private readonly Dice dice = new Dice();
        /// <summary>
        /// A private field for the roll counter.
        /// </summary>
        private int throwCounter = 0;
        /// <summary>
        /// A private field for the round counter.
        /// </summary>
        private int roundCounter = 0;
        /// <summary>
        /// A private field for the dices of the player.
        /// </summary>
        private readonly int[] dices = new int[6];
        /// <summary>
        /// A private field for the total points that gained in the game.
        /// </summary>
        private int total = 0;
        /// <summary>
        /// A private field for the score counter.
        /// </summary>
        private ScoreHandler scoreHandler = new ScoreHandler();


        /// <summary>
        /// It checks whether the game is over.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsGameOver()
        {
            return roundCounter == 10;
        }

        /// <summary>
        /// It initializes the values.
        /// </summary>
        public void Init()
        {
            throwCounter = 0;
            roundCounter = 0;
            total = 0;
            scoreHandler = new ScoreHandler();
        }

        /// <summary>
        ///It checks whether the user has rolled the first roll of the round.
        /// </summary>
        /// <returns></returns>
        public bool IsFirstRoll()
        {
            return throwCounter == 1;
        }

        /// <summary>
        /// It plays the game.
        /// </summary>
        /// <param name="isBehold">The dices that the player want to keep.</param>
        /// <returns>int[] the dices.</returns>
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

        /// <summary>
        /// It checks whether the round is over.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsRoundOver()
        {
            return throwCounter == 3;
        }

        /// <summary>
        /// It sets the counter upn a new round.
        /// </summary>
        public void SetRound()
        {
            throwCounter = 0;
        }

        /// <summary>
        /// It returns the total points were gained in the game.
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return total;
        }

        /// <summary>
        /// It returns the score of the round.
        /// </summary>
        /// <returns>GameArgs</returns>
        public GameArgs GetScore()
        {
            GameArgs gameArgs = scoreHandler.CountResult(dices);
            gameArgs.RoundNumber = roundCounter;
            total += gameArgs.Total;
            gameArgs.Combination = GetCombination(dices);
            return gameArgs;
        }

        /// <summary>
        /// It returns the number of the round.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentRound()
        {
            return roundCounter;
        }

        /// <summary>
        /// It returns the combination of the dices as string.
        /// </summary>
        /// <param name="dices">int[]</param>
        /// <returns>string</returns>
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
