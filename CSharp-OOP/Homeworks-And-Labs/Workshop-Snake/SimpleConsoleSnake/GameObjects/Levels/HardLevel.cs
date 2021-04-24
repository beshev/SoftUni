using System;

namespace SimpleConsoleSnake.GameObjects.Levels
{
    public class HardLevel : Level
    {
        private const int Middle_Left_X = 29;
        private const int Middle_Top_Y = 6;
        private const int Left_X = 5;
        private const int Top_Y = 6;
        private const int Vertical_Start_Point = 2;
        private const int Horizontal_Start_Point = 26;

        public HardLevel() : base(Left_X, Top_Y)
        { }

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

            for (int i = 0; i <= 6; i++)
            {
                int middleHorizontalLine = Middle_Left_X - 3 + i;

                this.levelPoints.Add(new Point(middleHorizontalLine, this.TopY + 3));
                this.Draw(Horizontal_Symbol, middleHorizontalLine, this.TopY + 3);
            }
        }

        protected override void SetVertical()
        {
            for (int i = 0; i <= 6; i++)
            {
                int middleVerticalLine = Middle_Top_Y + i;
                this.levelPoints.Add(new Point(Middle_Left_X, middleVerticalLine));
                this.Draw(Vertical_Symbol, Middle_Left_X, middleVerticalLine);
            }

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
