using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    public class Log : IPrint
    {
        public void PrintPlane(List<Plane> planeliste)
        {
            
        }
        public void PrintWarning(Plane plane1, Plane plane2)
        {
            using (StreamWriter fileWriter = new StreamWriter("Seperationslog.txt"))
            {
                fileWriter.WriteLine("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag + " at " + plane2._time);
            }

        }
    }
}
