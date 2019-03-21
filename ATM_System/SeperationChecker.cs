using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Events;

namespace ATM_System
{
    class SeperationChecker : ISeperationChecker
    {
        private IDataCalculator _calcedRecieved;
        
        private List<Plane> _planelist;
        public IPrint _print { get; set; }

        public SeperationChecker(IDataCalculator calcedRecieved)
        {
            this._calcedRecieved = calcedRecieved;

            this._calcedRecieved.CalcedDataReady += CheckDistance;

            _planelist = new List<Plane>();

           
        }



        public void CheckDistance(object sender, SeperationEventArgs e)
        {
            _planelist = e.CalcedInfo;
            foreach (var plane1 in _planelist)
            {
                foreach (var plane2 in _planelist)
                {
                    if (plane1._tag != plane2._tag)
                    {
                        double xdif = Math.Abs(plane1._xcoor - plane2._xcoor);
                        double ydif = Math.Abs(plane1._ycoor - plane2._ycoor);

                        double disth = Math.Sqrt(Math.Pow(xdif, 2) + Math.Pow(ydif, 2));
                        int distv = Math.Abs(plane1._altitude - plane2._altitude);

                        if (disth < 5000 && distv < 300)
                        {
                            PrinttoLog(_planelist);
                        }
                        else
                        {
                            PrinttoConsole(_planelist);
                        }
                    }
                }
            }
        }



        public void PrinttoLog(List<Plane> gammelliste)
        {
            _print = new Log();
            _print.PrintPlane(gammelliste);

        }

        public void PrintWarning(List<Plane> gammelliste)
        {
            _print = new ConsolePrint();
            
        }

        public void PrinttoConsole(List<Plane> gammelliste)
        {
            _print = new ConsolePrint();
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

