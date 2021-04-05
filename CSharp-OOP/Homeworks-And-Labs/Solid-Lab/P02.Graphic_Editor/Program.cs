using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEdito = new GraphicEditor();

            IShape shape = new Rectangle();
            Console.WriteLine(graphicEdito.DrawShape(shape));

            IShape shape1 = new Circle();
            Console.WriteLine(graphicEdito.DrawShape(shape1));

            IShape shape2 = new Square();
            Console.WriteLine(graphicEdito.DrawShape(shape2));

            IShape shape3 = new Triangle();
            Console.WriteLine(graphicEdito.DrawShape(shape3));
        }
    }
}
