using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_System
{
    public class TrackReciever : EventArgs
    {
        private ITransponderReceiver receiver;

        // Using constructor injection for dependency/ies
        public TrackReciever(ITransponderReceiver receiver, List<string> recevivedData)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;

            this.ReveivedData = recevivedData;

        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            // Just display data
            foreach (var data in e.TransponderData)
            {
                System.Console.WriteLine($"Transponderdata {data}");
            }
        }

        public List<string> ReveivedData { get; }
    }
}
