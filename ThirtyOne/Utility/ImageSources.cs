namespace ThirtyOne.Utility
{
    public class ImageSources
    {
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
