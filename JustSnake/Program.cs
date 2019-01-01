using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace JustSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState(40, 30, 70);
            var graphics = new Graphics(game);
            var window = graphics.CreateWindow();
            var eventHandler = new EventHandler(game, graphics, window);

            window.SetKeyRepeatEnabled(false);

            while (window.IsOpen)
            {
                game.Update();

                window.DispatchEvents();

                window.Clear();
                window.Draw(graphics);
                window.Display();
            }
        }
    }
}
