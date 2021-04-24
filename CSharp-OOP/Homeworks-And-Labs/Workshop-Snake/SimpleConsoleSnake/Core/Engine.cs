using SimpleConsoleSnake.Enums;
using SimpleConsoleSnake.GameObjects;
using SimpleConsoleSnake.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleConsoleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirections;
        private Snake snake;
        private Direction direction;
        private double sleepTime;

        public Engine(Snake snake)
        {
            this.sleepTime = 90;
            this.snake = snake;
            this.pointsOfDirections = new Point[4];
        }

        public void Run()
        {
            while (true)
            {
                GetDirections();
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirections[(int)direction]);

                if (!isMoving)
                {
                    Console.Clear();
                    AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void GetDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(10, 5);
            Console.Write("Would you like to continue? y/n");

            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.KeyChar == 'y')
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
            Console.Clear();
            Console.SetCursorPosition(23, 3);
            Console.WriteLine("Game over!!");
            Environment.Exit(0);
        }
    }
}
