using System;
using SFML.Graphics;

namespace JustSnake
{
    static class Colors
    {
        public static Color
            Background = new Color(43, 45, 66),
            Snake      = new Color(141, 153, 174),
            Food       = new Color(239, 35, 60);

        public static (byte, byte) RGBRange = (50, 200);


        static Random random = new Random();

        public static void Randomize()
        {
            var colors = new Color[3];

            for (int i = 0; i < 3; i++)
            {
                byte r = (byte)random.Next(RGBRange.Item1, RGBRange.Item2);
                byte g = (byte)random.Next(RGBRange.Item1, RGBRange.Item2);
                byte b = (byte)random.Next(RGBRange.Item1, RGBRange.Item2);

                colors[i] = new Color(r, g, b);
            }

            Background = colors[0];
            Snake      = colors[1];
            Food       = colors[2];
        }
    }
}
