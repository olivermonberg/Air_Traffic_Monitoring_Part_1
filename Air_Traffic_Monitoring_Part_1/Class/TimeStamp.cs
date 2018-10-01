﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    public class TimeStamp
    {
        public TimeStamp(int year, int month, int day, int hour, int min, int sec, int ms)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.min = min;
            this.sec = sec;
            this.ms = ms;
        }

        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int min { get; set; }
        public int sec { get; set; }
        public int ms { get; set; }

        public override string ToString()
        {
            return string.Format($"TimeStamp: Date: {day}-{month}-{year}, Time: {hour}:{min}:{sec}:{ms}");
        }
    }

}
