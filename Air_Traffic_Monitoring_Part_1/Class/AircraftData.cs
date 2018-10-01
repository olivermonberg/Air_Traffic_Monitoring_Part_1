using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    public class AircraftData
    {
        public AircraftData(string tag, int x_coordinate, int y_coordinate, int altitude, TimeStamp timeStamp)
        {
            Tag = tag;
            X_coordinate = x_coordinate;
            Y_coordinate = y_coordinate;
            Altitude = altitude;
            TimeStamp = timeStamp;
        }

        public string Tag { get; set; }
        public int X_coordinate { get; set; }
        public int Y_coordinate { get; set; }
        public int Altitude { get; set; }
        public TimeStamp TimeStamp { get; set; }

        public override string ToString()
        {
            return string.Format($"Tag: {Tag}, X: {X_coordinate}m, Y: {Y_coordinate}m, Alt: {Altitude}m, {TimeStamp}");
        }
    }
}
