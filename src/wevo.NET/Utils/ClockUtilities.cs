﻿using System;

namespace wevo.NET.Utils
{

    /**
    * Class for gathering clock utilities.
    */
    class ClockUtilities
    {
        /**
        * Returns timespan between two dates in seconds.
        * @param earlier Earlier date.
        * @param later Later date.
        * @return Length of timespan in seconds.
        */
        public static double GetTimeSpanInSeconds(DateTime earlier, DateTime later)
        {
            return (later - earlier).TotalSeconds;
        }

        /**
         * Returns timespan between given date and actual time (time of method call).
         * @param earlier Earlier date.
         * @return Length of timespan in seconds.
         */
        public static double GetTimeSpanInSeconds(DateTime earlier)
        {
            return GetTimeSpanInSeconds(DateTime.Now, earlier);
        }
    }
}
