using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace Air_Traffic_Monitoring_Part_1
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
            foreach (var item in args.TransponderData)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
