using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver; 

namespace ATM_System
{
    public class DataCalculator: IDataCalculator
    {
        private ITrackInfo _dataCalcRecieved;
        public List<Plane> nyliste { get; set; }
        public List<Plane> gammelliste { get; set; }

        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;
        }

        public void UseList(object sender, DataCalcEventArgs e)
        {
            nyliste = new List<Plane>();
            var list = e.DataList;
            
            foreach (var plane in list)
            {
                nyliste = list;
                Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor + " meters\nY-coordinate: " +
                                  plane._ycoor + " meters\nAltitude: " + plane._altitude + " meters\nTime stamp: " +
                                  plane._time.Year + "/" + plane._time.Month + "/" + plane._time.Day +
                                  ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                  plane._time.Second + " and " + plane._time.Millisecond +
                                  " milliseconds \nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                  plane._compassCourse + " degrees\n");
            }

        }
        //public void CalculateVelocity(Plane planeOld, Plane planeNew)
        //{

        //    double distance = Math.Sqrt(Math.Pow(planeOld._xcoor - planeNew._xcoor, 2) +
        //                                Math.Pow(planeOld._ycoor - planeNew._ycoor, 2) +
        //                                Math.Pow(planeOld._altitude - planeNew._altitude, 2));
        //    double time = (planeOld._time - planeNew._time).TotalSeconds;

        //    planeNew._velocity = (distance / time);


        //}

        //public void CalculateCourse(Plane planeOld, Plane planeNew)
        //{
        //    double slope = (planeOld._ycoor - planeNew._ycoor) / (planeOld._xcoor - planeNew._xcoor);

        //    planeNew._compassCourse = 90 - ((Math.Atan(slope) * 1800) / Math.PI);

        //}

        //public void CalculateVelocity(List<Plane> planeOld, List<Plane> planeNew)
        //{
        //    foreach (var planeO in planeOld)
        //    {
        //        foreach (var planeN in planeNew)
        //        {
        //            double distance = Math.Sqrt(Math.Pow(planeO._xcoor - planeN._xcoor, 2) +
        //                                        Math.Pow(planeO._ycoor - planeN._ycoor, 2) +
        //                                        Math.Pow(planeO._altitude - planeN._altitude, 2));
        //            double time = (planeO._time - planeN._time).TotalSeconds;

        //            planeN._velocity = (distance / time);
        //        }
        //    }


        //}

        //public void CalculateCourse(List<Plane> planeOld, List<Plane> planeNew)
        //{
        //    foreach (var planeO in planeOld)
        //    {
        //        foreach (var planeN in planeNew)
        //        {
        //            if (planeN._tag == planeO._tag)
        //            {
        //                double slope = (planeO._ycoor - planeN._ycoor) / (planeO._xcoor - planeN._xcoor);

        //                planeN._compassCourse = 90 - ((Math.Atan(slope) * 1800) / Math.PI);
        //            }

        //        }
        //    }

        //}
    }
}
