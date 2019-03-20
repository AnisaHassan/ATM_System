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
                CalculateVelocity();

                CalculateCourse(gammelliste, nyliste);
            }
            

           gammelliste = nyliste;
           // gammelliste = new List<Plane>(nyliste);

           
                Print(gammelliste);

           

           
        }


        public void CalculateVelocity()
        {
            foreach (var planeO in gammelliste)
            {
                foreach (var planeN in nyliste)
                {
                    if (planeN._tag == planeO._tag)

                    {
                        double distance = Math.Sqrt(Math.Pow(planeN._xcoor- planeO._xcoor , 2) +
                                                    Math.Pow(planeN._ycoor - planeO._ycoor, 2) +
                                                    Math.Pow(planeN._altitude - planeO._altitude, 2));

                        double time = (planeO._time - planeN._time).TotalSeconds;

                        velocity = distance / time;
                    }

                    //jeg tænker det er den 'gammle' liste der skal gemme velocity, da den 'nye' liste ikke skal gemmes her?
                    
                    planeN._velocity = Math.Round(velocity, 2);
                }
            }

        }

        public void CalculateCourse(List<Plane> gammelliste, List<Plane> nyliste)
        {
            foreach (var planeO in gammelliste)
            {
                foreach (var planeN in nyliste)
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


                            double radians = Math.Atan2(ydif, xdif);
                            double angle = radians * (180 / Math.PI);
                            if (angle < 0)
                            {
                                double gr = 90 + angle;
                                planeN._compassCourse = gr;
                            }
                            else
                            {
                                double gr = 90 - angle;
                                planeN._compassCourse = gr;
                            }


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
