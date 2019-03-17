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

        public TrackInfo() { }

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
                Plane p = new Plane();

                //Calculate if the plane is in our airspace
                if (p._xcoor <= 90000 && p._xcoor >= 10000 && p._ycoor >= 10000 && p._ycoor <= 90000)
                {
                    PlanesInAirSpaceList.Add(p);
                }
                
            }

            return PlanesInAirSpaceList;
        }

    }
}
