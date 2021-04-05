using System;
namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Rectangle(5, 5);
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());

        }
    }
}
