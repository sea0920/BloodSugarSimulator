using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Type
{
    public class Input
    {
        public InputType Type { get; set; }
        public int Id { get; set; }
        public long TimeStamp { get; set; }

        public Input(InputType type, int id, long timeStamp)
        {
            Type = type;
            Id = id;
            TimeStamp = timeStamp;
        }
    }
}