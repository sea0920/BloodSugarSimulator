using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Type
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseIndex { get; set; }

        public Exercise(int id, string name, int exerciseIndex)
        {
            Id = id;
            Name = name;
            ExerciseIndex = exerciseIndex;
        }
    }
}