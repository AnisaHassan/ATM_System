using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Events;
using TransponderReceiver;

namespace ATM_System
{
    public class DataCalculator: IDataCalculator
    {
        
        private ITrackInfo _dataCalcRecieved;
        public List<Plane> nyliste { get; set; }
        public List<Plane> gammelliste { get; set; }

        private double velocity;
        private IPrint _printToConsole;


        public event EventHandler<SeperationEventArgs> CalcedDataReady;

        public DataCalculator(ITrackInfo dataCalcRecieved)
        {
            this._dataCalcRecieved = dataCalcRecieved;

            this._dataCalcRecieved.AirspaceDataReady += UseList;

            gammelliste = new List<Plane>();

            _printToConsole = new ConsolePrint();

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

           
               // Print(gammelliste);


           CalcedDataReady?.Invoke(sender, new SeperationEventArgs(gammelliste));

        }


        public void CalculateVelocity()
        {
            foreach (var planeO in gammelliste)
            {
                foreach (var planeN in nyliste)
                {
                    if (planeN._tag == planeO._tag)

                    {
                        double xdif = Math.Abs(planeO._xcoor - planeN._xcoor);
                        double ydif = Math.Abs(planeO._ycoor - planeN._ycoor);
                        double adif = Math.Abs(planeN._altitude - planeO._altitude);

                        double distance = Math.Sqrt(Math.Pow(xdif , 2) +
                                                    Math.Pow(ydif, 2) +
                                                    Math.Pow(adif, 2));

                        double time = (planeO._time - planeN._time).TotalSeconds;

                        time = Math.Abs(time);

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
                        double xdif = planeN._xcoor - planeO._xcoor;
                        double ydif = planeN._ycoor - planeO._ycoor;

                        if (xdif == 0 && ydif > 0)
                        {
                            planeN._compassCourse = 0;
                        }
                        if (xdif == 0 && ydif < 0)
                        {
                            planeN._compassCourse = 180;
                        }

                        if (xdif < 0 && ydif == 0)
                        {
                            planeN._compassCourse = 90;
                        }
                        if (xdif > 0 && ydif == 0)
                        {
                            planeN._compassCourse = 270;
                        }

                        if (xdif > 0 && ydif > 0)
                        {
                            double radians = Math.Atan2(ydif, xdif);
                            double angle = radians * (180 / Math.PI);
                                double gr = 90 - angle;
                                planeN._compassCourse = gr;
                        }
                        if (xdif < 0 && ydif > 0)
                        {
                            double radians = Math.Atan2(Math.Abs(ydif), Math.Abs(xdif));
                            double angle = radians * (180 / Math.PI);
                            double gr = angle + 270;
                            planeN._compassCourse = gr;
                        }
                        if (xdif < 0 && ydif < 0)
                        {
                            double radians = Math.Atan2(Math.Abs(ydif), Math.Abs(xdif));
                            double angle = radians * (180 / Math.PI);
                            double gr = (270 - angle);
                            planeN._compassCourse = gr;
                        }
                        if (xdif > 0 && ydif < 0 )
                        {
                            double radians = Math.Atan2(Math.Abs(ydif), Math.Abs(xdif));
                            double angle = radians * (180 / Math.PI);
                            double gr = 90 + angle;
                            planeN._compassCourse = gr;
                        }

                    

                    }

                }
            }

        }


        
    }
}
