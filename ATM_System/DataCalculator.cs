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

        private double velocity;
        //Til udskrivning
        public IPrint _print { get; set; }
        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;

            gammelliste = new List<Plane>();

            _print = new ConsolePrint();
            
        }

        public DataCalculator() { }
        
        public void UseList(object sender, DataCalcEventArgs e)
        {
            //nyliste.Clear();
            
            //foreach (var plane in e.DataList)
            //{
            //    nyliste.Add(plane);
                
            //}
            nyliste = e.DataList;
            if (gammelliste != null)
            {
                CalculateVelocity(nyliste);

                CalculateCourse(gammelliste, nyliste);
            }
            

           gammelliste = nyliste;
           // gammelliste = new List<Plane>(nyliste);

           
                Print(gammelliste);

           
        }


        public void CalculateVelocity(List<Plane> nyliste)
        {
            foreach (var planeO in gammelliste)
            {
                foreach (var planeN in nyliste)
                {
                    if (planeN._tag == planeO._tag)

                    {
                        double distance = Math.Sqrt(Math.Pow(planeO._xcoor - planeN._xcoor, 2) +
                                                    Math.Pow(planeO._ycoor - planeN._ycoor, 2) +
                                                    Math.Pow(planeO._altitude - planeN._altitude, 2));

                        double time = (planeO._time - planeN._time).TotalSeconds;

                        velocity = distance / time;
                    }

                    //jeg tænker det er den 'gammle' liste der skal gemme velocity, da den 'nye' liste ikke skal gemmes her?
                    planeN._velocity = velocity;
                    //planeN._velocity = Math.Round(velocity, 2);
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
                               // Hvad så hvis ydiff er større eller mindre end 0?

                                planeN._compassCourse = 0;
                            
                        }
                        //mangler vi ikke nogle flere if sætninger?
                        // Hvad så hvis ydif er lig 0 og xdif er større eller mindre end 0?
                        //Eller de begge er større eller mindre end 0?, eller en er mindre og den anden er større?


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

        public void Print(List<Plane> gammelliste)
        {
            _print.PrintPlane(gammelliste);


            //list = gammelliste;
            //foreach (var plane in list)
            //{
            //    System.Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor +
            //                             " meters\nY-coordinate: " +
            //                             plane._ycoor + " meters\nAltitude: " + plane._altitude +
            //                             " meters\nTime stamp: " + plane._time.Year + "/" + plane._time.Month +
            //                             "/" + plane._time.Day +
            //                             ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
            //                             plane._time.Second + " and " + plane._time.Millisecond + " milliseconds");
            //}
        }
    }
}
