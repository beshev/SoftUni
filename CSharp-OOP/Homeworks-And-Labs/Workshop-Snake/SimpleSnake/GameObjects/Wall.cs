using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int x, int y) : base(x, y)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.Y);

            SetVerticalLine(0);
            SetVerticalLine(this.X - 1);
        }

        private void SetHorizontalLine(int y)
        {
            for (int x = 0; x < this.X; x++)
            {
                this.Draw(x, y, wallSymbol);
            }
        }

        private void SetVerticalLine(int x)
        {
            for (int y = 0; y < this.Y; y++)
            {
                this.Draw(x, y, wallSymbol);
            }
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.Y == 0 || snake.X == 0 || snake.Y == this.Y - 1 || snake.X == this.X - 1;
        }
    }
}
