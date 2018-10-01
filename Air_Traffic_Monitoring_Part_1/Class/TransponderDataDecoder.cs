using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    public class TransponderDataDecoder
    {
        public TransponderDataDecoder()
        {
            _Aircrafts = new List<AircraftData>();
        }

        public void UpdateTransponderData(List<string> _TransponderData)
        {
            foreach (var item in _TransponderData)
            {
                _Aircrafts.Add(DecodeString(item));
            }
        }

        public AircraftData DecodeString(string data)
        {
            string[] strArray = data.Split(';');

            int year = int.Parse(strArray[4].Substring(0, 4));
            int month = int.Parse(strArray[4].Substring(4, 2));
            int day = int.Parse(strArray[4].Substring(6, 2));
            int hour = int.Parse(strArray[4].Substring(8, 2));
            int min = int.Parse(strArray[4].Substring(10, 2));
            int sec = int.Parse(strArray[4].Substring(12, 2));
            int ms = int.Parse(strArray[4].Substring(14, 3));

            return new AircraftData(strArray[0], int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]),
                new TimeStamp(year, month, day, hour, min, sec, ms));
        }

        public List<AircraftData> _Aircrafts { get; set; }
    }
}
