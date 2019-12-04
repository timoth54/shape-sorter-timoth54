using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Rectangle(6, 7),
                new Circle(4.0),
                new Square(5.0),
                new Circle(8.0),
                new Square(10),
                new Rectangle(2.0, 4.0)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("-------------------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }

            Console.WriteLine("-------------------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("All circles");
            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }

            Console.WriteLine("-------------------------");

            IEnumerable<Circle> filteredCircles = shapes.OfType<Circle>().Where(circle => circle.Area < 30);
            Console.WriteLine("Circles with area < 30");
            foreach (Circle shape in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }

            Console.WriteLine("-------------------------");

            Console.WriteLine("Grouping By Area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Even Area" : "Odd Area");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }

            Console.WriteLine("-------------------------");

            Console.WriteLine("Group By Type");
            var groupByType = shapes.OrderBy(shape => shape.Area).GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                //Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach (var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} with area {shape.Area}");
                }
            }

            Console.ReadKey();
        }
    }
}
