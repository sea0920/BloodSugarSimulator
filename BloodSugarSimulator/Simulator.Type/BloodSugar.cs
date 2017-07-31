using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Type
{
    public class BloodSugar
    {
        public decimal Level { get; set; }
        public long Timestamp { get; set; }

        public BloodSugar(decimal level, long timeStamp)
        {
            Level = level;
            Timestamp = timeStamp;
        }
    }
}