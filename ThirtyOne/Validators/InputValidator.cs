using System.Text.RegularExpressions;

namespace ThirtyOne.Validators
{
    /// <summary>
    /// This is a validator class that validates objects.
    /// Author: Jacob Yousif
    /// </summary>
    public class InputValidator
    {

        /// <summary>
        /// It validates whether the string is valid.
        /// </summary>
        /// <param name="target">The string to be validated.</param>
        /// <returns>bool</returns>
        public bool IsValidString(string target)
        {
            return target != null && target.Length > 1;
        }

        /// <summary>
        /// It checks whether the string only contains letters.
        /// </summary>
        /// <param name="name">The name to be validated.</param>
        /// <returns>bool</returns>
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }
}
