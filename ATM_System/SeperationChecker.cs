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
        
        public List<Plane> _planelist;
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

            for (int i = 0; i < liste.Count - 1; i++)
            {
                for (int j = i + 1; j < liste.Count; j++)
                {
                    if (liste[i]._tag != liste[j]._tag)
                    {

                        double xdif = Math.Abs(liste[i]._xcoor - liste[j]._xcoor);
                        double ydif = Math.Abs(liste[i]._ycoor - liste[j]._ycoor);

                        double disth = Math.Sqrt(Math.Pow(xdif, 2) + Math.Pow(ydif, 2));
                        int distv = Math.Abs(liste[i]._altitude - liste[j]._altitude);

                        if (disth < 5000 && distv < 300)
                        {
                            PrintWarning(liste[i], liste[j]);
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

