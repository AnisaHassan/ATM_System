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
        private IPrint _printToLog;
        private IPrint _printToConsole;

        public SeperationChecker(IDataCalculator calcedRecieved, IPrint console, IPrint fil)
        {
            this._calcedRecieved = calcedRecieved;

            this._calcedRecieved.CalcedDataReady += CheckDistance;
            _planelist = new List<Plane>();
            _printToLog = new Log();

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
                            PrintToLog(_planelist);
                            PrintWarning();
                        }
                        
                    }
                }
            }
        }

        
        public void PrintToLog(List<Plane> gammelliste)
        {
            
            _printToLog.PrintPlane(gammelliste);

        }

        public void PrintWarning()
        {
            //denne her skal udkrive en linje med en advarelse..?
            string separationwarringningTConsole = "WARNING! Separation to small between " + 'plane1._tag' + " and " + 'plane2._tag' + " at " + 'blabla._time';
            //jeg kan ikke 'hente' de fly jeg skal udskrive..

            _printToConsole.PrintPlane(separationwarringningTConsole);

        }

    }
}

