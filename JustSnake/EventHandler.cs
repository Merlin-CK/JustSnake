using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace JustSnake
{
    /// <summary>
    /// Class that handles all of the events of a <c>Window</c> and
    /// changes a <c>GameState</c> and <c>Graphics</c> accordingly.
    /// This class simply needs to be instanciated once; after that you can
    /// simply use the <c>DispatchEvents()</c> method on the window and all
    /// events will be handled.
    /// </summary>
    class EventHandler
    {
        GameState game;
        Window window;
        Graphics graphics;

        public EventHandler(GameState game, Graphics graphics, Window window)
        {
            this.game = game;
            this.graphics = graphics;
            this.window = window;

            window.Closed += (_, __) => window.Close();
            window.KeyPressed += Window_KeyPressed;
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (game.GameOver)
            {
                game.Reset();
                return;
            }

            switch (e.Code)
            {
                case Keyboard.Key.Escape:
                    window.Close();
                    break;

                case Keyboard.Key.Up:
                case Keyboard.Key.W:
                    if (game.CurrentDirection != GameState.Direction.Down)
                    {
                        game.QueueDirection = GameState.Direction.Up;
                    }
                    break;

                case Keyboard.Key.Down:
                case Keyboard.Key.S:
                    if (game.CurrentDirection != GameState.Direction.Up)
                    {
                        game.QueueDirection = GameState.Direction.Down;
                    }
                    break;

                case Keyboard.Key.Left:
                case Keyboard.Key.A:
                    if (game.CurrentDirection != GameState.Direction.Right)
                    {
                        game.QueueDirection = GameState.Direction.Left;
                    }
                    break;

                case Keyboard.Key.Right:
                case Keyboard.Key.D:
                    if (game.CurrentDirection != GameState.Direction.Left)
                    {
                        game.QueueDirection = GameState.Direction.Right;
                    }
                    break;

                case Keyboard.Key.R:
                    Colors.Randomize();
                    graphics.ReloadColors();
                    break;
            }
        }
    }
}
