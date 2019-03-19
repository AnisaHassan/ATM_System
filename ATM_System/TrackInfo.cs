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
        public List<Plane> PlanesInAirSpaceList { get; set; }

        public TrackInfo(ITrackReciever dataReciever)
        {
            // This will store the real or the fake transponder data receiver
            this._dataReciever = dataReciever;

            // Attach to the event of the real or the fake TDR
            this._dataReciever.TrackedDataReady += ReceiverOnTrackedInfoDataReady;
        }

        public TrackInfo()
        {
        }

        public void ReceiverOnTrackedInfoDataReady(object sender, TrackedDataEventArgs e)
        {
            TrackedDataInfo = new List<Plane>();
            var list = e.TrackedInfo;

            foreach (var plane in list)
            {
                TrackedDataInfo = Airspace(list);
                
                    //Send information videre
                    AirspaceDataReady?.Invoke(sender, new DataCalcEventArgs(TrackedDataInfo));

                
            }

        }

        public List<Plane> Airspace(List<Plane> planeliste)
        {
            PlanesInAirSpaceList = new List<Plane>();

            foreach (var plane in planeliste)
            {

                //Calculate if the plan is in our airspace
                if (plane._xcoor <= 90000 && plane._xcoor >= 10000 && plane._ycoor >= 10000 && plane._ycoor <= 90000)
                {
                    //Plane p = new Plane();
                    PlanesInAirSpaceList.Add(plane);

                }

            }
            return PlanesInAirSpaceList;

        }
    }
}
