using System.Collections.Generic;
using System.Windows.Controls;
using ThirtyOne.Args;
using ThirtyOne.Logger;

namespace ThirtyOne.ViewHandlers
{
    /// <summary>
    /// This is a class for handling the thelist view..
    /// Author: Jacob Yousif
    /// </summary>
    public class ViewScoreManager
    {
        /// <summary>
        /// A private field for the scores.
        /// </summary>
        private List<ScoreArgs> scores;

        /// <summary>
        /// It updates the scores in the file and in the list view.
        /// </summary>
        /// <param name="score">The score.</param>
        /// <param name="listView">The ListView</param>
        public void UpdateScores(ScoreArgs score, ListView listView)
        {
            scores.Add(score);
            scores.Sort();
            XMLSerializerUtility.XMLSerialize(scores);
            int index = 0;
            listView.Items.Clear();
            foreach (ScoreArgs item in scores)
            {
                listView.Items.Insert(index++, item);
            }
        }

        /// <summary>
        /// It populates the scores by reading from the scores file.
        /// </summary>
        /// <param name="listView">The ListView</param>
        public void PopulateScores(ListView listView)
        {

            int index = 0;
            scores = XMLSerializerUtility.XMLDeSerialize<ScoreArgs>();
            if (scores != null)
            {
                scores.Sort();
                foreach (ScoreArgs item in scores)
                {
                    listView.Items.Insert(index++, item);
                }
            }
            else
            {
                scores = new List<ScoreArgs>();
            }
        }

    }
}