using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class ConsolePrint : IPrint
    {
        private List<Plane> _gammellist;

        public ConsolePrint()
        {
            _gammellist = new List<Plane>();
        }
        public void PrintPlane(List<Plane> gammellist)
        {
            _gammellist = gammellist;

            if (_gammellist != null)
            {
                foreach (var plane in _gammellist)
                {
                    System.Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor +
                                             " meters\nY-coordinate: " +
                                             plane._ycoor + " meters\nAltitude: " + plane._altitude +
                                             " meters\nTime stamp: " + plane._time.Year + "/" + plane._time.Month +
                                             "/" + plane._time.Day +
                                             ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                             plane._time.Second + " and " + plane._time.Millisecond + " milliseconds\nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                    plane._compassCourse + " degrees\n");
                }
            }
        }

        public void PrintWarning(Plane plane1, Plane plane2, DateTime time)
        {
            Console.WriteLine("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag + " at " + time);

        }
    }
}
