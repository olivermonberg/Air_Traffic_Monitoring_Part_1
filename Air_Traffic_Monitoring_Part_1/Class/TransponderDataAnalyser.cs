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
            //FilteredAircrafts = new List<AircraftData>();
        }
        public void AnalyseData(List<AircraftData> _aircrafts)
        {
            List<AircraftData> _FilterAircrafts = FilterAircrafts(_aircrafts);

            /*
            foreach (var item1 in _FilterAircrafts)
            {
                foreach (var item2 in _FilterAircrafts)
                {
                    if (CheckForCollision(item1, item2) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"WARNING! Collision between flight {item1.Tag} and {item2.Tag}.");
                        Console.ResetColor();
                    }
                }
            }*/

            for (int i = 0; i < _FilterAircrafts.Count(); i++)
            {
                for (int j = i + 1; j < _FilterAircrafts.Count(); j++)
                {
                    if (CheckForCollision(_FilterAircrafts[i], _FilterAircrafts[j]) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"WARNING! Collision between flight {_FilterAircrafts[i].Tag} " +
                                          $"and {_FilterAircrafts[j].Tag}.");
                        Console.ResetColor();
                    }
                }   
            }

        }

        private bool CheckForCollision(AircraftData obj1, AircraftData obj2)
        {
            /*
            if (obj1 == obj2)
            {
                return false;
            }*/

            int AltDiff = Math.Abs(obj1.Altitude - obj2.Altitude);
            int Dist = (int)Math.Sqrt(Math.Pow((obj2.X_coordinate - obj1.X_coordinate),2) + 
                                      Math.Pow((obj2.Y_coordinate-obj1.Y_coordinate),2));

            if (AltDiff <= 300 && Dist <= 5000)
            {
                return true;
            }

            return false;
        }

        private List<AircraftData> FilterAircrafts(List<AircraftData> _list)
        {
            List<AircraftData> FilteredAircrafts = new List<AircraftData>();

            foreach (var item in _list)
            {
                if ((item.Altitude >= 500 && item.Altitude <= 20000) &&
                    (item.X_coordinate >= 10000 && item.X_coordinate <= 90000) &&
                    (item.Y_coordinate <= 90000 && item.Y_coordinate >= 10000))
                {
                    FilteredAircrafts.Add(item);
                }
            }

            return FilteredAircrafts;
        }
    }
}
