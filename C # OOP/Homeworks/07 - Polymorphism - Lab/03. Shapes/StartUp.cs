using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Shape shapes = new Rectangle(-5, 6);
                Console.WriteLine($"{shapes.CalculateArea():f2}");
                Console.WriteLine($"{shapes.CalculatePerimeter():f2}");
                Console.WriteLine(shapes.Draw());
                Console.WriteLine();
                Shape shape = new Circle(-4);
                Console.WriteLine($"{shape.CalculateArea():f2}");
                Console.WriteLine($"{shape.CalculatePerimeter():f2}");
                Console.WriteLine(shape.Draw());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
