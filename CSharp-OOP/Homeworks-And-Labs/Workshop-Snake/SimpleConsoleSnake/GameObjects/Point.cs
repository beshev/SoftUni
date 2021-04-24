using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX { get; set; }

        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(char symbol,int leftX,int topY)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
