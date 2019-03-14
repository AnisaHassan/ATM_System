using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_System
{
    public class TrackInfo : ITrackInfo
    {
     

        //Used to recive event from TrackReciever class
        private ITrackReciever _dataReciever;
        public List<Plane> TrackedDataInfo { get; set; }


        //Used to new Event 
        public event EventHandler<DataCalcEventArgs> AirspaceDataReady;

        public TrackInfo(ITrackReciever dataReciever)
        {
            // This will store the real or the fake transponder data receiver
            this._dataReciever = dataReciever;

            // Attach to the event of the real or the fake TDR
            this._dataReciever.TrackedDataReady += AirSpace;
        }

        public TrackInfo()
        {

        }




        public void AirSpace(object sender, TrackedDataEventArgs e)
        {
             TrackedDataInfo = new List<Plane>();


            foreach (var plane in e.TrackedInfo)
            {
                if (plane._xcoor <= 90000 && plane._xcoor >= 10000 && plane._ycoor >= 10000 && plane._ycoor <= 90000)
                {
                    TrackedDataInfo.Add(plane);

                }

                //Send information videre
                AirspaceDataReady?.Invoke(sender, new DataCalcEventArgs(TrackedDataInfo));

            }
        }


        
    }

}


