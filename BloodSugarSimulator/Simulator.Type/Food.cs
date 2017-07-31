using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Type
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GlycemicIndex { get; set; }

        public Food(int id, string name, int glycemicIndex)
        {
            Id = id;
            Name = name;
            GlycemicIndex = glycemicIndex;
        }
    }
}