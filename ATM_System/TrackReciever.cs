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
        private TrackInfo _trackinfo;
        public List<Plane> ReceivedDataList { get; set; }

        // Using constructor injection for dependency/ies
        public TrackReciever(ITransponderReceiver receiver, TrackInfo trackInfo)
        {
            receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
            //// This will store the real or the fake transponder data receiver
            //this.receiver = receiver;

            //// Attach to the event of the real or the fake TDR
            //this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;

            _trackinfo = trackInfo;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var list = e.TransponderData;
            ReceivedDataList = TrackedInfo(list);
            _trackinfo.Print(ReceivedDataList);


            //foreach (var data in e.TransponderData)
            //{
            //    //Just display data
            //    //System.Console.WriteLine($"Transponderdata {data}");

            //    // Move data to TrackInfo
            //    ReceivedDataList = TrackedInfo(data);
            //    TrackedDataReady.Invoke(sender, new TrackedDataEventArgs(ReceivedDataList));

            //}

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
