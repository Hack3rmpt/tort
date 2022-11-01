using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace магазинтортовреворк
{
    class Order
    {
        public List<Point> points;
        string[] order = new string[3];
        int[] BuffCost = new int[3];
        int cost = 0;
        public Order(List<Point> points)
        {
            this.points = points;
        }

        public void ChoosePoint(ref int PointerPosition)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ShowPoints();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("->");
            while (true)
            {
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow && PointerPosition != points.Count - 1)
                {
                    PointerPosition++;
                }

                if (keyInfo.Key == ConsoleKey.UpArrow && PointerPosition != 0)
                {
                    PointerPosition--;
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    ChooseSubPoint(ref PointerPosition);
                }
                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    bool flag = true;
                    foreach (var item in order)
                    {
                        if (item == null)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        string path = @"C:\Users\МБОУ ЦО 2\Desktop\CakeOrder.txt";
                        if (!File.Exists(@"C:\Users\МБОУ ЦО 2\Desktop\CakeOrder.txt"))
                        {
                            File.Create(path);
                        }
                        var sw = new StreamWriter(path, true);
                        sw.WriteLine($"\n\n\nВаш заказ: {order[0]}{order[1]}{order[2]}\nОбщая стоимость: {cost}\n{DateTime.Now.ToString()}");
                        sw.Close();
                    }
                }
                Console.Clear();
                ShowPoints();
                Console.WriteLine($"\n\n\nВаш заказ: {order[0]}{order[1]}{order[2]}\nОбщая стоимость: {cost}");
                Console.WriteLine("Чтобы закончить заказ нажмите Tab");
                Console.SetCursorPosition(0, PointerPosition);
                Console.WriteLine("->");
            }

        }
        public void ShowPoints()
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"  {i + 1}){points[i]}");
            }
        }
        public void ChooseSubPoint(ref int PointerPosition)
        {
            int buffer = PointerPosition;
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            points[buffer].ShowSubPoints();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("->");
            while (keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow && PointerPosition != points[buffer].subpoints.Length - 1)
                {
                    PointerPosition++;
                }

                if (keyInfo.Key == ConsoleKey.UpArrow && PointerPosition != 0)
                {
                    PointerPosition--;
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    order[buffer] = points[buffer].ToString() + ": " + points[buffer].subpoints[PointerPosition] + ";";
                    BuffCost[buffer] = points[buffer].subpoints[PointerPosition].cost;
                    cost = 0;
                    foreach (var item in BuffCost) cost += item;

                }
                Console.Clear();
                points[buffer].ShowSubPoints();
                Console.SetCursorPosition(0, PointerPosition);
                Console.WriteLine("->");

            }


        }
    }
}
