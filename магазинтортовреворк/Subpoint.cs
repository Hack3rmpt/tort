using System;
using System.Collections.Generic;
using System.Text;

namespace магазинтортовреворк
{
  public class Subpoint
    {
        public string nameOfSubpoint;
        public int cost;
        public Subpoint(string name, int cost)
        {
            this.cost = cost;
            nameOfSubpoint = name;
        }
        public override string ToString()
        {
            return $"{nameOfSubpoint} - {cost} руб.";
        }
    }
}
