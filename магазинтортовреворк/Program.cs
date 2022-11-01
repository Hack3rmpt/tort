using System.Collections.Generic;
using System;
using System.IO;

namespace магазинтортовреворк
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points;
            int PointerPosition = 0;
            Point p1 = new Point("Форма торта");
            p1.AddSubPoints(new string[] { "Круглый", "Квадратный", "Треугольный", "Шестиугольный" }, new int[] { 500, 300, 250, 700 });

            Point p2 = new Point("Вкус торта");
            p2.AddSubPoints(new[] { "Шоколадный", "Ягодный", "Молочный" }, new[] { 400, 435, 300 });

            Point p3 = new Point("Вес");
            p3.AddSubPoints(new[] { "7 кг.", "14 кг", "21 кг" }, new[] { 700, 1300, 2000 });

            points = new List<Point>() { p1, p2, p3 };

            Order r = new Order(points);

            r.ChoosePoint(ref PointerPosition);

        }
    }
}
