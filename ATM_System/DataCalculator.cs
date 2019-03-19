using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver; 

namespace ATM_System
{
    public class DataCalculator: IDataCalculator
    {
        private ITrackInfo _dataCalcRecieved;
        public List<Plane> nyliste { get; set; }
        
        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;
            nyliste = new List<Plane>();
            gammelliste = new List<Plane>();
        }

        public DataCalculator()
        {
           
        }

        public void UseList(object sender, DataCalcEventArgs e)
        {
            gammelliste = nyliste;
            nyliste = e.DataList;
            
            foreach (var plane in nyliste)
            {
                //nyliste.Add(plane);

                CalculateVelocity(gammelliste, nyliste);

                CalculateCourse(gammelliste, nyliste);

                Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor + " meters\nY-coordinate: " +
                                  plane._ycoor + " meters\nAltitude: " + plane._altitude + " meters\nTime stamp: " +
                                  plane._time.Year + "/" + plane._time.Month + "/" + plane._time.Day +
                                  ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                  plane._time.Second + " and " + plane._time.Millisecond +
                                  " milliseconds \nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                  plane._compassCourse + " degrees\n");
            }


        }


        public void CalculateVelocity(List<Plane> planeOld, List<Plane> planeNew)
        {
            foreach (var planeO in planeOld)
            {
                foreach (var planeN in planeNew)
                {
                    double distance = Math.Sqrt(Math.Pow(planeO._xcoor - planeN._xcoor, 2) +
                                                Math.Pow(planeO._ycoor - planeN._ycoor, 2) +
                                                Math.Pow(planeO._altitude - planeN._altitude, 2));
                    double time = (planeO._time - planeN._time).TotalSeconds;

                    planeN._velocity = (distance / time);
                }
            }


        }

        public void CalculateCourse(List<Plane> planeOld, List<Plane> planeNew)
        {
            foreach (var planeO in planeOld)
            {
                foreach (var planeN in planeNew)
                {
                    if (planeN._tag == planeO._tag)
                  
                    {
                        double xdif = planeO._xcoor - planeN._xcoor;
                        double ydif = planeO._ycoor - planeN._ycoor;

                        if (xdif == 0)
                        {
                            planeN._compassCourse = 0;
                            
                        }

                        else
                        {
                            //double slope = ydif / xdif;

                            double gr = (Math.Atan2(ydif, xdif) * 180.0 / Math.PI);
                            if (gr < 0 )
                            {
                               gr = gr + 360;
                                planeN._compassCourse = gr;
                            }
                            //((Math.Atan(slope) * 180) / Math.PI);
                        }
                        
                    }

                }
            }

        }
    }
}
