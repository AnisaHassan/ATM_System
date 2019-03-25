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
        public string _text { get; set; }

        public ConsolePrint()
        {
            _gammellist = new List<Plane>();
           // _text = new String();
            
        }
        public void PrintPlane(List<Plane> gammellist)
        {
            _gammellist = gammellist;

            if (_gammellist != null)
            {
                foreach (var plane in _gammellist)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    _text = ("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor +
                                             " meters\nY-coordinate: " +
                                             plane._ycoor + " meters\nAltitude: " + plane._altitude +
                                             " meters\nTime stamp: " + plane._time.Year + "/" + plane._time.Month +
                                             "/" + plane._time.Day +
                                             ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                             plane._time.Second + " and " + plane._time.Millisecond + " milliseconds\nVelocity: " + plane._velocity + " m/s\nCourse: " +
                                    plane._compassCourse + " degrees\n");
                    Console.WriteLine(_text);
                }
            }
        }

        public void PrintWarning(Plane plane1, Plane plane2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _text = ("WARNING! Separation too small between " + plane1._tag + " and " + plane2._tag + " at " + plane2._time);
            Console.WriteLine(_text);
        }
    }
}
