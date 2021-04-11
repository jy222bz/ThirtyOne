namespace ThirtyOne.Exceptions
{
    /// <summary>
    /// This is a subclass that extends from thr super class; the base exception.
    /// Author: Jacob Yousif
    /// </summary>
    public class FileSerializationException : BaseException
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public FileSerializationException() : base("There is a problem with writing into the scores file!")
        {

        }
    }
}
