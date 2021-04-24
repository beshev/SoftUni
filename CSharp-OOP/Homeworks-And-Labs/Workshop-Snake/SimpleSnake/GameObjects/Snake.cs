using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;
        private Food[] food;
        private Wall wall;
        private int nextX;
        private int nextY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.food = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
            this.CreateFirstFood();
        }

        private int RandomFoodNumber => new Random().Next(0, this.food.Length);


        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(p => p.X == this.nextX && p.Y == this.nextY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextX, this.nextY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point direction,Point currentSnakeHead)
        {
            int length = food[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextX, this.nextY));
                GetNextPoint(direction, currentSnakeHead);
            }
            this.foodIndex = this.RandomFoodNumber;
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void CreateSnake()
        {
            for (int Y = 1; Y <= 6; Y++)
            {
                this.snakeElements.Enqueue(new Point(2, Y));
            }
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextX = snakeHead.X + direction.X;
            this.nextY = snakeHead.Y + direction.Y;
        }

        private void CreateFirstFood()
        {
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
