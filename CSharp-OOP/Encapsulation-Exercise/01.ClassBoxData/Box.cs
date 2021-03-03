using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.length = length;
            this.width = width;
            this.height = height;
        }


        public double SurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }
    }
}
