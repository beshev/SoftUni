using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleSnake.GameObjects.Levels
{
    public abstract class Level : Point
    {
        protected const char Vertical_Symbol = '*';
        protected const char Horizontal_Symbol = '*';

        protected readonly List<Point> levelPoints;
        protected Level(int leftX, int topY) : base(leftX, topY)
        {
            this.levelPoints = new List<Point>();
            this.Initialize();
        }

        public IReadOnlyCollection<Point> LevelPoints => this.levelPoints.AsReadOnly();

        private void Initialize()
        {
            this.SetHorizontal();
            this.SetVertical();
        }

        protected abstract void SetHorizontal();

        protected abstract void SetVertical();
    }
}
