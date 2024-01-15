using System;

namespace LSP.Violation
{
    public class CalculateArea
    {
        private static void GetRectangleArea(Rectangle rectangle)
        {
            Console.WriteLine(rectangle.Height + " * " + rectangle.Width);
            Console.WriteLine();
            Console.WriteLine(rectangle.Area);
            Console.ReadKey();
        }

        public static void Calcular()
        {
            var square = new Square()
            {
                Height = 10,
                Width = 5
            };

            GetRectangleArea(square);
        }
    }
}
