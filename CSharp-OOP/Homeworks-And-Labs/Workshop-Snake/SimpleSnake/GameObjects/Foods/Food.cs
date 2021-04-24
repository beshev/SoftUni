using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Wall wall;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points) : base(wall.X, wall.Y)
        {
            this.wall = wall;
            this.FoodPoints = points;   
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.X = random.Next(2, wall.X - 2);
            this.Y = random.Next(2, wall.Y - 2);

            bool isPointOFSnake = snakeElements
                .Any(x => x.X == this.X && x.Y == this.Y);

            while (isPointOFSnake)
            {
                this.X = random.Next(2, wall.X - 2);
                this.Y = random.Next(2, wall.Y - 2);

                isPointOFSnake = snakeElements
                      .Any(x => x.X == this.X && x.Y == this.Y);

            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.Y == this.Y && snake.X == this.X;
        }
    }
}
