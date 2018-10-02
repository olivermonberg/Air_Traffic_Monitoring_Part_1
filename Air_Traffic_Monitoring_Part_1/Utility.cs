﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    public class Utility
    {
        public static int CalcDistance(AircraftData obj1, AircraftData obj2)
        {
            return (int)Math.Sqrt(Math.Pow((obj2.X_coordinate - obj1.X_coordinate), 2) +
                                  Math.Pow((obj2.Y_coordinate - obj1.Y_coordinate), 2));
        }

        public static int ConvertTimeToMilliseconds(AircraftData obj)
        {
            int hour = obj.TimeStamp.hour * 60 * 60 * 1000;
            int minut = obj.TimeStamp.min * 60 * 1000;
            int sec = obj.TimeStamp.sec * 1000;

            return hour + minut + sec + obj.TimeStamp.ms;
        }

        public static double Speed(AircraftData newPosition, AircraftData oldPosition)
        {
            int timeDiff = Math.Abs(ConvertTimeToMilliseconds(newPosition) - ConvertTimeToMilliseconds(oldPosition));

            return CalcDistance(newPosition, oldPosition) / ((double)timeDiff / 1000);
        }
    }
}
