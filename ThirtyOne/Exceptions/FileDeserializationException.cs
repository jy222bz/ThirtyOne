namespace ThirtyOne.Exceptions
{
    /// <summary>
    /// This is a subclass that extends from thr super class; the base exception.
    /// Author: Jacob Yousif
    /// </summary>
    public class FileDeserializationException : BaseException
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public FileDeserializationException() : base("There is a problem with loading the scores file!")
        {
        }
    }
}
