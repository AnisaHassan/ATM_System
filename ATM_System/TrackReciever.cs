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
        public event EventHandler<TrackedDataEventArgs> TrackedDataReady;

        private ITransponderReceiver receiver;
        public List<Plane> ReceivedDataList { get; set; }

        // Using constructor injection for dependency/ies
        public TrackReciever(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;

           
        }

        public TrackReciever() { }
        public void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
           // ReceivedDataList = new List<Plane>();
            var list = e.TransponderData;

           
           // Move data to TrackInfo
           
            ReceivedDataList = TrackedInfo(list);

    
            TrackedDataReady?.Invoke(sender, new TrackedDataEventArgs(ReceivedDataList));
            
        

        }

        public List<Plane> TrackedInfo(List<string> planeliste)
        {
            List<Plane> ConverteretInfo = new List<Plane>();

            foreach (var info in planeliste)
            {
                string[] _plane;
                _plane = info.Split(';');

                Plane p = new Plane();

                //Convert string to usable data.
                p._tag = _plane[0];
                p._xcoor = Convert.ToInt32(_plane[1]);
                p._ycoor = Convert.ToInt32(_plane[2]);
                p._altitude = Convert.ToInt32(_plane[3]);

                p._time = DateTime.ParseExact(_plane[4], "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);


                p._compassCourse = 0;
                p._velocity = 0;

                
                ConverteretInfo.Add(p);
            }

            return ConverteretInfo;



        }

    }
}
