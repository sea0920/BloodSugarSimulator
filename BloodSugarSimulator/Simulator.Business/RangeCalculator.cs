using BloodSugarSimulator.Simulator.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodSugarSimulator.Simulator.Util;

namespace BloodSugarSimulator.Simulator.Business
{
    public class RangeCalculator
    {
        /// <summary>
        /// Get timestamp for start date of the inputs interval. Inclusive.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public long GetStartDateTimeStamp(List<Input> inputs)
        {
            long start = inputs.Min(o => o.TimeStamp);
            DateTime startDateTime = start.ToDateTime();
            long startTimeStamp = new DateTime(startDateTime.Year, startDateTime.Month, startDateTime.Day).ToTimeStamp();
            return startTimeStamp;
        }

        /// <summary>
        /// Get timestamp for end date of the inputs interval. Exclusive.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public long GetEndDateTimeStamp(List<Input> inputs)
        {
            long end = inputs.Max(o => o.TimeStamp);
            DateTime endDateTime = end.ToDateTime().AddDays(1);
            long endTimeStamp = new DateTime(endDateTime.Year, endDateTime.Month, endDateTime.Day).ToTimeStamp();
            return endTimeStamp;
        }
    }
}