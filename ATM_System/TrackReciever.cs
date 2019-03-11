using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_System
{
    public class TrackReciever : ITrackReciever
    {
        private ITransponderReceiver receiver;
        public Plane TransponderReceivedData { get; set; }

        public event EventHandler<TrackedDataEventArgs> TrackedDataReady;

        // Using constructor injection for dependency/ies
        public TrackReciever(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;

            

        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {

            foreach (var data in e.TransponderData)
            {
                //Just display data
                //System.Console.WriteLine($"Transponderdata {data}");

                // Move data to TrackInfo
                TransponderReceivedData = TrackedInfo(data);
                TrackedDataReady.Invoke(sender, new TrackedDataEventArgs(TransponderReceivedData));
                
            }
            
        }

        public Plane TrackedInfo(string data)
        {
            //Convert string to usable data.
            string[] inputFields;
            inputFields = data.Split(';');
            TransponderReceivedData = new Plane(Convert.ToString(inputFields[0]), Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToInt32(inputFields[3]), Convert.ToString(inputFields[4]), "", 0);

            return TransponderReceivedData;
        }

    }
}
