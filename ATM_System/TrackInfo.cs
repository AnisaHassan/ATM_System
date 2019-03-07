using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class TrackInfo
    {
        private ITrackReciever trackInfo;
       
        public Plane TrackedDataInfo { get; set; }

        public TrackInfo(ITrackReciever trackInfo)
        {
            // This will store the real or the fake transponder data receiver
            this.trackInfo = trackInfo;

            // Attach to the event of the real or the fake TDR
            this.trackInfo.TrackedDataReady += ReceiverOnTrackInfoDataReady;
        }

        private void ReceiverOnTrackInfoDataReady(object sender, TrackedDataEventArgs e)
        {
            TrackedDataInfo = e.TrackedInfo;

            System.Console.WriteLine("Transponderdata Tag: {0} Position: {1},{2} Altitude: {3}, Datetime: {4}", TrackedDataInfo._tag, TrackedDataInfo._xcoor, TrackedDataInfo._ycoor, TrackedDataInfo._altitude, TrackedDataInfo._time);
        }

       


    }

}
