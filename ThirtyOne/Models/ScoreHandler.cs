using System;
using System.Collections.Generic;
using ThirtyOne.Args;

namespace ThirtyOne.Models
{
    /// <summary>
    /// This class represents a ScoreCalculator object, where its task to count the scores of the game
    /// based on the available options.
    /// Ten options are available at the beginning of the game. Each option is allowed to be used once during the game.
    /// The options are 12-4 and LOW, where LOW represents the dices that are below the value of four.
    /// This class implements Parcelable to serialize it.
    /// It provides a method that returns result; the option that was chosen for the calculation and the score.
    /// Source: Jacob Yousif from previous work.
    /// Author: Jacob Yousif
    /// </summary>
    public class ScoreHandler
    {
        /// <summary>
        /// This private field represents the all the options for the game.
        /// </summary>
        private readonly int[] mOptions = new int[10];

        /// <summary>
        /// This private field represents all the boolean values, each boolean value associates with an option.
        /// </summary>
        private readonly bool[] mIsTheOptionAvailable = new bool[13];

        /// <summary>
        /// Constructor to create a ScoreCalculator object.
        /// Initializes the values of the options from 12 - 3, where THREE(3) is the option LOW.
        /// Initializes the values of the boolean array, where the boolean value at an index
        /// will represent an option.The value of the index will refer to the option
        /// that corresponds to the value of the index.
        /// Example: The boolean value in index 12, represents the option 12.
        /// </summary>
        public ScoreHandler()
        {
            int option = 12;
            for (int index = 0; index < 10; index++)
            {
                mIsTheOptionAvailable[option] = true;
                mOptions[index] = option--;
            }
        }

        /// <summary>
        /// It returns the result of the round.
        /// It returns an 2D int array.
        /// The first column of the array holds the option was chosen and the second column holds the score.
        /// This method depends on a private method group_counter(), to calculate the score.
        /// This method organizes and sorts the values based on the available options
        /// and send them forward to the private method.
        /// The score will be counted based on the available options.
        /// It receives from the private method all the scores that were calculated based on the available options.
        /// The method chooses the option that gives the highest score possible and it blocks the option afterwards.
        /// The option will be chosen just once during the game.Once it gets blocked it will not be used again.
        /// The input array is allowed to contain none-negative values only, that are greater than zero.
        /// Furthermore, duplicates in the input array are allowed.As individual elements, each
        /// element cannot be used more than once.
        /// </summary>
        /// <param name="theValuesOfTheDices"></param>
        /// <returns></returns>
        public GameArgs CountResult(int[] theValuesOfTheDices)
        {
            int[] options = new int[10];
            int[] scores = new int[10];
            int optionLow = 3;
            Array.Sort(theValuesOfTheDices);
            options[9] = optionLow;
            scores[9] = 0;

            if (mIsTheOptionAvailable[mOptions[9]])
            {
                foreach (var item in theValuesOfTheDices)
                {
                    if (item < 4)
                    {
                        scores[9] += item;
                    }
                }
            }

            for (int index = 0; index < mOptions.Length - 1; index++)
            {
                if (mIsTheOptionAvailable[mOptions[index]])
                {
                    int groups = GroupCounter(theValuesOfTheDices, mOptions[index]);
                    options[index] = mOptions[index];
                    scores[index] = (groups * mOptions[index]);
                }
            }

            int index0fBigest = 0;
            int biggest = 0;

            for (int index = 0; index < scores.Length; index++)
            {
                if (biggest < scores[index])
                {
                    biggest = scores[index];
                    index0fBigest = index;
                }
            }

            mIsTheOptionAvailable[options[index0fBigest]] = false;
            string option = "Low";

            if (index0fBigest != 9)
            {
                option = options[index0fBigest].ToString();
            }
            return new GameArgs(biggest, option);
        }


        /// <summary>
        /// The task of this method is to divide the input array into groups that equal the targeted
        /// value and count the groups that fulfill the condition.
        /// Each value of the input array will be used once.
        /// The input array can have duplicates but as individual elements, each element can be used to
        /// belong to one unique subgroup only.
        /// If the element cannot be formed to any subgroup then it will be discarded.
        /// This method returns the amount of the groups that equal the targeted value.
        /// The mechanism of this method, that it goes linearly, element by element, first to see
        /// whether the element is equal to the target.
        /// If it is, it counts it and blocks it from being used again, if it is not the case,
        /// then the method, in this case, tries to pair it with another available element to become equal
        /// to the targeted value.If it is not the case, then the next step is to form groups of three
        /// elements to make their sum equal to the targeted value.
        /// If none of the above fulfilled the condition, or there are at least four unused elements
        /// then the method takes the last step which is to form
        /// a group of either 4, 5, or 6 elements to make their sum equal to the target.
        /// </summary>
        /// <param name="theSetOfValues"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int GroupCounter(int[] theSetOfValues, int target)
        {
            int currentTotal;
            bool[] mTheValueIsNotUsed = new bool[] { true, true, true, true, true, true };
            int max = theSetOfValues.Length;
            int amountOfGroupsEqualTheTarget = 0;

            for (int index = 0; index < max; index++)
            {
                if (theSetOfValues[index] == target && mTheValueIsNotUsed[index])
                {
                    mTheValueIsNotUsed[index] = false;
                    amountOfGroupsEqualTheTarget++;
                }

                if (mTheValueIsNotUsed[index] & index != max - 1)
                {
                    for (int i = max - 1; i > index; i--)
                    {
                        if (theSetOfValues[index] + theSetOfValues[i] == target &&
                                mTheValueIsNotUsed[index] && mTheValueIsNotUsed[i])
                        {
                            mTheValueIsNotUsed[index] = false;
                            mTheValueIsNotUsed[i] = false;
                            amountOfGroupsEqualTheTarget++;
                        }
                    }
                }
            }

            bool areThereAvailableElements = mTheValueIsNotUsed[0] || mTheValueIsNotUsed[1] || mTheValueIsNotUsed[2]
                    || mTheValueIsNotUsed[3] || mTheValueIsNotUsed[4] || mTheValueIsNotUsed[5];

            if (areThereAvailableElements)
            {
                for (int index = 0; index < max - 2; index++)
                {
                    if (mTheValueIsNotUsed[index])
                    {
                        for (int j = index + 1; j < max - 1; j++)
                        {
                            if (mTheValueIsNotUsed[j])
                            {
                                for (int k = j + 1; k < max; k++)
                                {
                                    if (theSetOfValues[k] + theSetOfValues[j] + theSetOfValues[index] == target &&
                                            mTheValueIsNotUsed[k] && mTheValueIsNotUsed[index]
                                            && mTheValueIsNotUsed[j])
                                    {
                                        mTheValueIsNotUsed[j] = false;
                                        mTheValueIsNotUsed[index] = false;
                                        mTheValueIsNotUsed[k] = false;
                                        amountOfGroupsEqualTheTarget++;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (areThereAvailableElements)
            {
                for (int i = 0; i < theSetOfValues.Length; i++)
                {
                    if (mTheValueIsNotUsed[i])
                    {
                        currentTotal = theSetOfValues[i];
                        for (int j = i + 1; j < theSetOfValues.Length; j++)
                        {
                            if (currentTotal == target)
                            {
                                amountOfGroupsEqualTheTarget++;
                                for (int x = i; x < j; x++)
                                    mTheValueIsNotUsed[i] = false;
                                break;
                            }

                            else if (currentTotal > target)
                                break;

                            if (mTheValueIsNotUsed[j])
                                currentTotal += theSetOfValues[j];
                        }
                    }
                }
            }
            return amountOfGroupsEqualTheTarget;
        }

    }
}
