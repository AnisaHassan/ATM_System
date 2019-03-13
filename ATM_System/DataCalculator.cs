using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class DataCalculator : IDataCalculator
    {
        private ITrackInfo _dataCalcRecieved;
        public List<Plane> CalculatedDataList { get; set; }

        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;
        }

        public void UseList(object sender, DataCalcEventArgs e)
        {
            CalculatedDataList = new List<Plane>();

            foreach (var plane in e.DataList)
            {

                //Bar for at se om listen er kommet med (Det er den (: )
                Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor + " meters\nY-coordinate: " +
                                  plane._ycoor + " meters\nAltitude: " + plane._altitude + " meters\nTime stamp: " +
                                  plane._time.Year + "/" + plane._time.Month + "/" + plane._time.Day +
                                  ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                  plane._time.Second + " and " + plane._time.Millisecond +
                                  " milliseconds \nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                  plane._compassCourse + " degrees\n");
            }
        }
        public void CalculateVelocity(Plane planeOld, Plane planeNew)
        {

            double distance = Math.Sqrt(Math.Pow(planeOld._xcoor - planeNew._xcoor, 2) +
                                        Math.Pow(planeOld._ycoor - planeNew._ycoor, 2) +
                                        Math.Pow(planeOld._altitude - planeNew._altitude, 2));
            double time = (planeOld._time - planeNew._time).TotalSeconds;

            planeNew._velocity = (distance / time);


        }

        public void CalculateCourse(Plane planeOld, Plane planeNew)
        {
            double slope = (planeOld._ycoor - planeNew._ycoor) / (planeOld._xcoor - planeNew._xcoor);

            planeNew._compassCourse = 90 - ((Math.Atan(slope) * 1800) / Math.PI);

        }
    }
}
