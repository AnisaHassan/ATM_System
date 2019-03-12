using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class ConsolePrint : IPrint
    {
        public void PrintPlane(List<Plane> planelise)
        {

            if (planelise.Count != 0)
            {
                foreach (var plane in planelise)
                {
                    System.Console.WriteLine("Tag: " + plane._tag + "\nX-coordinate: " + plane._xcoor +
                                             " meters\nY-coordinate: " +
                                             plane._ycoor + " meters\nAltitude: " + plane._altitude +
                                             " meters\nTime stamp: " + plane._time.Year + "/" + plane._time.Month +
                                             "/" + plane._time.Day +
                                             ", at " + plane._time.Hour + ":" + plane._time.Minute + ":" +
                                             plane._time.Second + " and " + plane._time.Millisecond + " milliseconds");
                }
            }               
        }
    }
}
