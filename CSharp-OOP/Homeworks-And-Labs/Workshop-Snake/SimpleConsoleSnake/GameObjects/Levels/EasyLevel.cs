using System;

namespace SimpleConsoleSnake.GameObjects.Levels
{
    public class EasyLevel : Level
    {
        private const int Left_X = 28;
        private const int Top_Y = 6;

        public EasyLevel() : base(Left_X, Top_Y)
        {
        }

        protected override void SetHorizontal()
        {
            for (int i = 0; i <= 6; i++)
            {
                int horizontalLine = Left_X - 3 + i;

                this.levelPoints.Add(new Point(horizontalLine, this.TopY + 3));
                this.Draw(Horizontal_Symbol, horizontalLine, this.TopY + 3);
            }
        }

        protected override void SetVertical()
        {
            for (int i = 0; i <= 6; i++)
            {
                int verticalLine = Top_Y + i;
                this.levelPoints.Add(new Point(this.LeftX, verticalLine));
                this.Draw(Vertical_Symbol, this.LeftX, verticalLine);
            }
        }
    }
}
