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

   
       
        public List<Plane> TrackedDataInfo { get; set; }

        public TrackInfo()
        {
            //// This will store the real or the fake transponder data receiver
            //this.trackInfo = trackInfo;

            //// Attach to the event of the real or the fake TDR
            //this.trackInfo.TrackedDataReady += ReceiverOnTrackInfoDataReady;
        }

        //private void ReceiverOnTrackInfoDataReady(object sender, TrackedDataEventArgs e)
        //{
        //    foreach (var plane in TrackedDataInfo)
        //    {
        //System.Console.WriteLine("Transponderdata Tag: {0} Position: {1},{2} Altitude: {3}, Datetime: {4}", TrackedDataInfo._tag, TrackedDataInfo._xcoor, TrackedDataInfo._ycoor, TrackedDataInfo._altitude, TrackedDataInfo._time);

        //         }



        //    //System.Console.WriteLine("Transponderdata Tag: {0} Position: {1},{2} Altitude: {3}, Datetime: {4}", TrackedDataInfo._tag, TrackedDataInfo._xcoor, TrackedDataInfo._ycoor, TrackedDataInfo._altitude, TrackedDataInfo._time);
        //}

        public void Airspace(List<Plane> planeliste)
        {
            //foreach (var plane in TrackedDataInfo)
            //{
            //    System.Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor + " meters\nY-coordinate: " +
            //                             plane._ycoor + " meters\nAltitude: " + plane._altitude + " meters\nTime stamp: " + plane._time.Year + "/" + plane._time.Month + "/" + plane._time.Day +
            //                             ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" + plane._time.Second + " and " + plane._time.Millisecond + " milliseconds");
            //}
        }


    }

}
