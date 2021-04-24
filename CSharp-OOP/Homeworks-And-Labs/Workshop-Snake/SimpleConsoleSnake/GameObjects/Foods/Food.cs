using SimpleConsoleSnake.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleConsoleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Random random;
        private char foodSymbol;

        protected Food(char foodSymbol, int foodPoints) : base(0, 0)
        {
            this.foodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;
            random = new Random();
        }

        public int FoodPoints { get; }

        public void SetRandomPositions(Queue<Point> snakeElements,Level level)
        {
            this.LeftX = random.Next(2, Console.BufferWidth - 2);
            this.TopY = random.Next(2, Console.BufferHeight - 2);

            while (IsPointOfSnake(snakeElements) || IsPointOfLevel(level))
            {
                this.LeftX = random.Next(2, Console.BufferWidth - 2);
                this.TopY = random.Next(2, Console.BufferHeight - 2);
            }

            Console.SetCursorPosition(this.LeftX, this.TopY);
            this.Draw(this.foodSymbol);

        }

        public bool IsPointOfSnake(Queue<Point> snakeElements)
        {
            return snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }

        private bool IsPointOfLevel(Level level)
        {
            return level.LevelPoints.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }
    }
}
