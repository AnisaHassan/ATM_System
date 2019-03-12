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



        //public void AirSpace(List<Track> trackList)
        
            {
               // foreach (var track in trackList.ToList())
                {
                    //if (track._xcoor <= 90000 && track._xcoor >= 10000 && track._ycoor >= 10000 &&
                        //track._ycoor <= 90000)
                        //trackList.Add(RecievedData);
                   
                }

         
        }

    }

}
