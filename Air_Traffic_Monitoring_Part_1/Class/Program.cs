using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace Air_Traffic_Monitoring_Part_1.Class
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            receiver.TransponderDataReady += hooker;

            Console.ReadKey();
        }

        public static void hooker(object o, RawTransponderDataEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Received transponder data:");

            TransponderDataDecoder decoder = new TransponderDataDecoder();

            decoder.UpdateTransponderData(args.TransponderData);

            TransponderDataAnalyser analyser = new TransponderDataAnalyser();

            analyser.AnalyseData(decoder._Aircrafts);

            foreach (var item in decoder._Aircrafts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
