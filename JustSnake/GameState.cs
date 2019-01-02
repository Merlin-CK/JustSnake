using System;
using System.Collections.Generic;
using SFML.System;

namespace JustSnake
{
    /// <summary>
    /// Class for all the game logic
    /// </summary>
    class GameState
    {
        public enum CellType { None, Snake, Food }
        public enum Direction { None, Up, Down, Left, Right }

        public int Rows    { get; private set; }
        public int Columns { get; private set; }

        public int Interval { get; set; }
        public uint Score { get; private set; } = 0;
        public bool GameOver { get; private set; } = false;
        public string Message { get; private set; } = "Score: 0";

        public Vector2i FoodPosition { get; private set; }

        public LinkedList<Vector2i> snakePositions
            = new LinkedList<Vector2i>();

        public Direction CurrentDirection { get; private set; } = Direction.None;
        public Direction QueueDirection   { get; set; } = Direction.None;


        Clock clock = new Clock();
        Random random = new Random();


        public GameState(int columns, int rows, int intervalMilliseconds)
        {
            Columns = columns;
            Rows = rows;
            Interval = intervalMilliseconds;

            Reset();
        }

        public void Update()
        {
            if (!GameOver && clock.ElapsedTime.AsMilliseconds() >= Interval)
            {
                CurrentDirection = QueueDirection;
                MoveSnake();
                clock.Restart();
            }
        }

        public void Reset()
        {
            var snakePos = new Vector2i(Columns / 2, Rows / 2);
            snakePositions.Clear();
            snakePositions.AddFirst(snakePos);

            Score = 0;
            Message = $"Score: 0";

            QueueDirection = Direction.None;
            CurrentDirection = Direction.None;

            NewFood();

            GameOver = false;
        }

        void MoveSnake()
        {
            var lastPos = snakePositions.Last.Value;
            var newPos = new Vector2i(lastPos.X, lastPos.Y);

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newPos.Y--;
                    break;

                case Direction.Down:
                    newPos.Y++;
                    break;

                case Direction.Left:
                    newPos.X--;
                    break;

                case Direction.Right:
                    newPos.X++;
                    break;
            }

            if (newPos.X < 0 || newPos.X >= Columns ||
                newPos.Y < 0 || newPos.Y >= Rows ||
                (CurrentDirection != Direction.None &&
                 snakePositions.Contains(newPos)))
            {
                SetGameOver();
                return;
            }
            else if (newPos == FoodPosition)
            {
                Score++;
                Message = $"Score: {Score}";
                NewFood();
            }
            else
            {
                snakePositions.RemoveFirst();
            }

            snakePositions.AddLast(newPos);
        }

        void NewFood()
        {
            Vector2i newPos;

            do
            {
                newPos = new Vector2i(
                    random.Next(0, Columns),
                    random.Next(0, Rows)
                );
            } while (snakePositions.Contains(newPos));

            FoodPosition = newPos;
        }

        void SetGameOver()
        {
            GameOver = true;
            Message += "\n\nGame over!\nPress any key to play again";
        }
    }
}
