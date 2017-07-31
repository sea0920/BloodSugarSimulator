using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Util
{
    public static class DateTimeUtil
    {
        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            DateTime baseDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            baseDateTime = baseDateTime.AddMilliseconds(unixTimeStamp);
            return baseDateTime;
        }

        public static long ToTimeStamp(this DateTime datetime)
        {
            DateTime baseDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return (datetime.Ticks - baseDateTime.Ticks) / 10000;
        }
    }
}