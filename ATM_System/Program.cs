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
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TrackInfo trackInfo = new TrackInfo();
            List<Plane> list = new List<Plane>();
            // Dependency injection with the real TDR
            var trackInfoRecieved = new TrackReciever(receiver, trackInfo);

            trackInfo.Airspace(list);

           // var trackedInfo = new TrackInfo(trackInfoRecieved);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
