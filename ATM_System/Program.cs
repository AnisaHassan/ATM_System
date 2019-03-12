using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM_System;

namespace ATM_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the real transponder data receiver
            ITransponderReceiver receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TrackInfo trackInfo = new TrackInfo();
            
            ITrackReciever trackReciever = new TrackReciever(receiver, trackInfo);
            IPrint console = new ConsolePrint();
            trackInfo.Printlist();

            Console.ReadKey();


        }
    }
}
