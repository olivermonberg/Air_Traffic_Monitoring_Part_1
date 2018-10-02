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
            receiver.TransponderDataReady += eventHandler;

            Console.ReadKey();
        }

        static TransponderDataDecoder _decoder = new TransponderDataDecoder();

        public static void eventHandler(object o, RawTransponderDataEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Received transponder data:");
            
            _decoder.UpdateTransponderData(args.TransponderData);

            TransponderDataAnalyser analyser = new TransponderDataAnalyser();

            analyser.AnalyseData(_decoder._Aircrafts);

            foreach (var item in analyser._FilteredAircrafts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
