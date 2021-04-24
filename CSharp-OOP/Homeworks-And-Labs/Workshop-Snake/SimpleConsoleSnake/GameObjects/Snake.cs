using SimpleConsoleSnake.Enums;
using SimpleConsoleSnake.GameObjects.Foods;
using SimpleConsoleSnake.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleConsoleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char symbol = '\u25CF';
        private Queue<Point> snakeElements;
        private int nextLefX;
        private int nextTopY;
        private Food[] foods;
        private int foodIndex;
        private Level level;

        public Snake(int leftX, int topY,Level level) : base(leftX, topY)
        {
            this.foods = new Food[3];
            this.snakeElements = new Queue<Point>();
            this.foodIndex = RandomFoodIndex;
            this.level = level;
            CreateFood();
            CreateSnake();
            CreateFirstFood();
        }

        private int RandomFoodIndex => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            Point currentHead = this.snakeElements.Last();
            GetNextPosition(direction, currentHead);

            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == this.nextLefX && x.TopY == this.nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            if (IsSave() == false)
            {
                ChangePotionOfBoardPoint();
            }

            if (IsPointOfLevel(this.level))
            {
                return false;
            }

            Point newHead = new Point(this.nextLefX, this.nextTopY);

            if (this.foods[foodIndex].IsPointOfSnake(this.snakeElements))
            {
                Eat();
            }


            this.snakeElements.Enqueue(newHead);
            newHead.Draw(symbol);
            this.snakeElements.Dequeue().Draw(' ');
            return true;
        }

        private void Eat()
        {
            for (int i = 0; i < this.foods[this.foodIndex].FoodPoints; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLefX, this.nextTopY));
            }
            this.foodIndex = this.RandomFoodIndex;
            this.foods[foodIndex].SetRandomPositions(this.snakeElements,this.level);
        }

        private void CreateFirstFood()
        {
            this.foods[foodIndex].SetRandomPositions(this.snakeElements,this.level);
        }

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                this.snakeElements.Enqueue(new Point(1, 1));
            }
        }

        private void GetNextPosition(Point direction, Point currentHead)
        {
            this.nextLefX = direction.LeftX + currentHead.LeftX;
            this.nextTopY = direction.TopY + currentHead.TopY;
        }

        private bool IsSave()
        {
            return (this.nextLefX < Console.BufferWidth && this.nextLefX >= 0)
                && (this.nextTopY < Console.BufferHeight && this.nextTopY >= 0);
        }

        private void ChangePotionOfBoardPoint()
        {
            if (this.nextLefX < 0)
            {
                this.nextLefX = Console.BufferWidth - 1;
            }
            else if (this.nextLefX >= Console.BufferWidth)
            {
                this.nextLefX = 0;
            }

            if (this.nextTopY < 0)
            {
                this.nextTopY = Console.BufferHeight - 1;
            }
            else if (this.nextTopY >= Console.BufferHeight)
            {
                this.nextTopY = 0;
            }
        }

        private void CreateFood()
        {
            this.foods[0] = new DollarFood();
            this.foods[1] = new HashFood();
            this.foods[2] = new CircleFood();
        }

        private bool IsPointOfLevel(Level level)
        {
            return level.LevelPoints.Any(x => x.LeftX == this.nextLefX && x.TopY == this.nextTopY);
        }
    }
}
