using System;

namespace SimpleConsoleSnake.GameObjects.Levels
{
    public class MediumLevel : Level
    {
        private const int Left_X = 5;
        private const int Top_Y = 6;
        private const int Vertical_Start_Point = 2;
        private const int Horizontal_Start_Point = 26;


        public MediumLevel() : base(Left_X, Top_Y) { }

        protected override void SetHorizontal()
        {
            int verticalLine = Vertical_Start_Point;
            int horizontalLine = Horizontal_Start_Point;
            for (int i = 0; i <= 6; i++)
            {
                this.levelPoints.Add(new Point(horizontalLine, verticalLine));
                this.Draw(Horizontal_Symbol, horizontalLine, verticalLine);
                horizontalLine++;
            }

            verticalLine = Console.BufferHeight - Vertical_Start_Point - 1;
            horizontalLine = Horizontal_Start_Point;
            for (int i = 0; i <= 6; i++)
            {
                this.levelPoints.Add(new Point(horizontalLine, verticalLine));
                this.Draw(Horizontal_Symbol, horizontalLine, verticalLine);
                horizontalLine++;
            }
        }

        protected override void SetVertical()
        {
            int verticalLine = Top_Y;
            int horizontalLine = Left_X;
            for (int i = 0; i < 6; i++)
            {
                this.levelPoints.Add(new Point(horizontalLine, verticalLine));
                this.Draw(Vertical_Symbol, horizontalLine, verticalLine);
                verticalLine++;
            }

            horizontalLine = Console.BufferWidth - Left_X;
            verticalLine = TopY;
            for (int i = 0; i < 6; i++)
            {
                this.levelPoints.Add(new Point(horizontalLine, verticalLine));
                this.Draw(Vertical_Symbol, horizontalLine, verticalLine);
                verticalLine++;
            }
        }
    }
}
