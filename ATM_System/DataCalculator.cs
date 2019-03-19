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
        public List<Plane> gammelliste { get; set; }
        public IPrint _print { get; set; }
        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;
            
        }

        public DataCalculator() { }
        
        public void UseList(object sender, DataCalcEventArgs e)
        {
            var list = e.DataList;
            nyliste.Clear();
            
            foreach (var plane in list)
            {
                nyliste.Add(plane);
            }

            CalculateVelocity(gammelliste, nyliste);

            CalculateCourse(gammelliste, nyliste);

            gammelliste = new List<Plane>(nyliste);
            Print();
        }


        public void CalculateVelocity(List<Plane> planeOld, List<Plane> planeNew)
        {
            foreach (var planeO in planeOld)
            {
                foreach (var planeN in planeNew)
                {
                    if (planeN._tag == planeO._tag)

                    {
                        double distance = Math.Sqrt(Math.Pow(planeO._xcoor - planeN._xcoor, 2) +
                                                    Math.Pow(planeO._ycoor - planeN._ycoor, 2) +
                                                    Math.Pow(planeO._altitude - planeN._altitude, 2));
                        double time = (planeO._time - planeN._time).TotalSeconds;

                        planeN._velocity = (distance / time);
                    }
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

        public void Print()
        {
            _print.PrintPlane(gammelliste);
        }
    }
}
