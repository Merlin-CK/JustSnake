using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace JustSnake
{
    /// <summary>
    /// Class that draws a <c>GameState</c>.
    /// </summary>
    class Graphics : Drawable
    {
        public const uint CELL_SIZE = 15;

        GameState game;

        RectangleShape rectangle = new RectangleShape(
            new Vector2f(CELL_SIZE, CELL_SIZE)
        );

        Color textColorAddition = new Color(50, 50, 50);
        RectangleShape gameOverBackground;
        Text text;
        

        public Graphics(GameState gameState)
        {
            game = gameState;

            text = new Text("Score: 0", Resources.Font);
            text.Position = new Vector2f(10, 10);

            gameOverBackground = new RectangleShape(
                new Vector2f(
                    game.Columns * CELL_SIZE,
                    game.Rows * CELL_SIZE
                )
            );

            gameOverBackground.FillColor = new Color(0, 0, 0, 150);

            ReloadColors();
        }

        public RenderWindow CreateWindow()
        {
            var videoMode = new VideoMode(
                (uint)game.Columns * CELL_SIZE,
                (uint)game.Rows * CELL_SIZE
            );
            
            return new RenderWindow(videoMode, "JustSnake", Styles.Close);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int x = 0; x < game.Columns; x++)
            {
                for (int y = 0; y < game.Rows; y++)
                {
                    target.Draw(MakeCell(x, y, Colors.Background));
                }
            }

            target.Draw(MakeCell(
                game.FoodPosition.X,
                game.FoodPosition.Y,
                Colors.Food
            ));

            foreach (var pos in game.snakePositions)
            {
                target.Draw(
                    MakeCell(pos.X, pos.Y, Colors.Snake)
                );
            }

            if (game.GameOver)
            {
                target.Draw(gameOverBackground);
            }

            text.DisplayedString = game.Message;
            target.Draw(text);
        }

        RectangleShape MakeCell(int x, int y, Color color)
        {
            rectangle.Position = new Vector2f(CELL_SIZE * x, CELL_SIZE * y);
            rectangle.FillColor = color;
            return rectangle;
        }

        public void ReloadColors()
        {
            text.FillColor = Colors.Background + textColorAddition;
        }
    }
}
