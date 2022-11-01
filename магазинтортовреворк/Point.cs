using System;
using System.Collections.Generic;
using System.Text;

namespace магазинтортовреворк
{
   public class Point
    {
        public string NameOfPoint;
        public Subpoint[] subpoints;
        public Point(string name, Subpoint[] sp)
        {
            NameOfPoint = name;
            subpoints = sp;
        }
        public Point(string name)
        {
            NameOfPoint = name;
        }
        public void ShowSubPoints()
        {
            foreach (var item in subpoints)
            {
                Console.WriteLine($"   {item}");
            }
        }
        public void AddSubPoints(string[] namesOfSubpoints, int[] costOfSubPoints) //удобная инициализация подпунктов
        {
            subpoints = new Subpoint[namesOfSubpoints.Length];
            for (int i = 0; i < namesOfSubpoints.Length; i++)
            {
                subpoints[i] = new Subpoint(namesOfSubpoints[i], costOfSubPoints[i]);
            }
        }
        public override string ToString()
        {
            return NameOfPoint;
        }
    }
}
