using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Events;

namespace ATM_System
{
    public class SeperationChecker : ISeperationChecker
    {
        private IDataCalculator _calcedRecieved;
        
        private List<Plane> _planelist;
        private IPrint _printToLog;
        private IPrint _printToConsole;

        public SeperationChecker(IDataCalculator calcedRecieved, IPrint printer1, IPrint printer2)
        {
            this._calcedRecieved = calcedRecieved;

            this._calcedRecieved.CalcedDataReady += CheckDistance;
            _planelist = new List<Plane>();
            _printToLog = printer1;
            _printToConsole = printer2;

        }

      

        public void CheckDistance(object sender, SeperationEventArgs e)
        {
            _planelist = e.CalcedInfo;
            
            PrintToConsole(_planelist);

            DistanceChecker(_planelist);
        }


        public void DistanceChecker(List<Plane> liste)
        {

            foreach (var plane1 in liste)
            {
                foreach (var plane2 in liste)
                {
                    if (plane1._tag != plane2._tag)
                    {
                        double xdif = Math.Abs(plane1._xcoor - plane2._xcoor);
                        double ydif = Math.Abs(plane1._ycoor - plane2._ycoor);

                        double disth = Math.Sqrt(Math.Pow(xdif, 2) + Math.Pow(ydif, 2));
                        int distv = Math.Abs(plane1._altitude - plane2._altitude);

                        if (disth < 5000 && distv < 300)
                        {
                            PrintWarning(plane1, plane2);
                        }

                    }
                }
            }
        }

       

        public void PrintWarning(Plane plane1, Plane plane2)
        {
            _printToLog.PrintWarning(plane1, plane2);
            _printToConsole.PrintWarning(plane1, plane2);

        }

        public void PrintToConsole(List<Plane> gammelliste)
        {
            _printToConsole.PrintPlane(gammelliste);
        }

    }
}

