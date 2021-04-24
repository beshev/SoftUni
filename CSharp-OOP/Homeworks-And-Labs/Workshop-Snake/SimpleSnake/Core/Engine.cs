using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] _pointsOfDirection;
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Wall wall,Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this._pointsOfDirection = new Point[4];
        }
        public void Run()
        {
            CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }
                

                bool isMoving = snake.IsMoving(this._pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }
                this.sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }

        }

        private void AskUserForRestart()
        {
            int x = this.wall.X + 1;
            int y = 3;

            Console.SetCursorPosition(x, y);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            Console.CursorVisible = false;
        }

        private void CreateDirections()
        {
            this._pointsOfDirection[0] = new Point(1, 0);
            this._pointsOfDirection[1] = new Point(-1, 0);
            this._pointsOfDirection[2] = new Point(0, 1);
            this._pointsOfDirection[3] = new Point(0, -1);
        }
    }
}
