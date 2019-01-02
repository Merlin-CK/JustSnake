using SFML.Audio;
using SFML.Graphics;

namespace JustSnake
{
    static class Resources
    {
        public static Font Font { get; private set; }

        public static void Load()
        {
            Font = new Font("Font/ABeeZee-Regular.otf");
        }
    }
}
