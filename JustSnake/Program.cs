using System;
using System.IO;

namespace JustSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Resources.Load();

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
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
        }
    }
}
