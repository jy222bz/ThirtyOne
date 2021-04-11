using System;

namespace ThirtyOne.Exceptions
{
    /// <summary>
    /// This is a super class for the base exception.
    /// Author: Jacob Yousif
    /// </summary>
    public class BaseException : Exception
    {

        /// <summary>
        /// A nprivate field for the error message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Public constroctor.
        /// </summary>
        /// <param name="message">The error message.</param>
        public BaseException(string message) : base(message)
        {
            this.message = message;
        }

        /// <summary>
        /// It returns the error message.
        /// </summary>
        /// <returns>The message.</returns>
        public string GetMessage()
        {
            return message;
        }
    }
}