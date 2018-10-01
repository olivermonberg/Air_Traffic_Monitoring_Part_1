using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    public class TransponderDataAnalyser
    {
        public TransponderDataAnalyser()
        {
            _FilteredAircrafts = new List<AircraftData>();
        }
        public void AnalyseData(List<AircraftData> _aircrafts)
        {
            FilterAircrafts(_aircrafts);

            for (int i = 0; i < _FilteredAircrafts.Count(); i++)
            {
                for (int j = i + 1; j < _FilteredAircrafts.Count(); j++)
                {
                    if (CheckForCollision(_FilteredAircrafts[i], _FilteredAircrafts[j]) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"WARNING! Collision between flight {_FilteredAircrafts[i].Tag} " +
                                          $"and {_FilteredAircrafts[j].Tag}.");
                        Console.ResetColor();
                    }
                }   
            }
        }

        private bool CheckForCollision(AircraftData obj1, AircraftData obj2)
        {
            /*if (obj1 == obj2)
            {
                return false;
            }*/

            int AltDiff = Math.Abs(obj1.Altitude - obj2.Altitude);
            int Dist = CalcDistance(obj1, obj2);
                                      
            if (AltDiff <= 300 && Dist <= 5000)
            {
                return true;
            }

            return false;
        }
        /*
        void printVelocityAndCourse()
        {
            foreach (var item in _FilteredAircrafts)
            {
                Console.WriteLine($"Tag: {}");
            }
        }*/

        public static int CalcDistance(AircraftData obj1, AircraftData obj2)
        {
            return (int)Math.Sqrt(Math.Pow((obj2.X_coordinate - obj1.X_coordinate), 2) +
                                  Math.Pow((obj2.Y_coordinate - obj1.Y_coordinate), 2));
        }

        private void FilterAircrafts(List<AircraftData> _list)
        {
            List<AircraftData> FilteredAircrafts = new List<AircraftData>();

            foreach (var item in _list)
            {
                if ((item.Altitude >= 500 && item.Altitude <= 20000) &&
                    (item.X_coordinate >= 10000 && item.X_coordinate <= 90000) &&
                    (item.Y_coordinate <= 90000 && item.Y_coordinate >= 10000))
                {
                    _FilteredAircrafts.Add(item);
                }
            }
            //return FilteredAircrafts;
        }

        public List<AircraftData> _FilteredAircrafts;
    }
}
