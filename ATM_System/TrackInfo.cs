using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_System
{
    public class TrackInfo
    {
        private ITrackReciever _dataReciever;
        public List<Plane> TrackedDataInfo { get; set; }
        private IDataCalculator _dataCalculator;
       

        public TrackInfo(ITrackReciever dataReciever)
        {
            // This will store the real or the fake transponder data receiver
            this._dataReciever = dataReciever;

            // Attach to the event of the real or the fake TDR
            this._dataReciever.TrackedDataReady += ReceiverOnTrackedDataReady;

        }

       

        private void ReceiverOnTrackedDataReady(object sender, TrackedDataEventArgs e)
        {
            //AirSpace(TrackedDataInfo);

            foreach (var plane in TrackedDataInfo)
            {

                Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor + " meters\nY-coordinate: " +
                                  plane._ycoor + " meters\nAltitude: " + plane._altitude + " meters\nTime stamp: " +
                                  plane._time.Year + "/" + plane._time.Month + "/" + plane._time.Day +
                                  ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                  plane._time.Second + " and " + plane._time.Millisecond +
                                  " milliseconds \nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                  plane._compassCourse + " degrees\n");
            }
        }
        public void AirSpace(List<Plane> planelist)

        {
            TrackedDataInfo = new List<Plane>();

            foreach (var _plane in planelist)
            {
                if (_plane._xcoor <= 90000 && _plane._xcoor >= 10000 && _plane._ycoor >= 10000 &&
                    _plane._ycoor <= 90000)

                    TrackedDataInfo.Add(_plane);
            }
           

        }

    }

}
