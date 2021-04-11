namespace ThirtyOne.Utility
{
    /// <summary>
    /// This is a class for the Images' Paths.
    /// Author: Jacob Yousif
    /// </summary>
    public class ImageSources
    {
       
        /// <summary>
        /// It returns an array of the images' paths.
        /// </summary>
        /// <returns>string[]</returns>
        public static string[] GetSources()
        {
            string[] paths = new string[6];
            for (int index = 0; index < 6; ++index)
            {
                int order = index + 1;
                paths[index] = "/Images/dice" + order + ".png";
            }

            return paths;
        }
    }
}
