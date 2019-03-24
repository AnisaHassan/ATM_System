using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class Log : IPrint
    {
        public void PrintPlane(List<Plane> planeliste)
        {
            
        }
        public void PrintWarning(Plane plane1, Plane plane2, DateTime time)
        {
            using (StreamWriter fileWriter = new FileInfo("Seperationslog.txt").AppendText())
            {
                fileWriter.WriteLine("WARNING! Separation to small between " + plane1._tag + " and " + plane2._tag + " at " + time);
            }

        }
    }
}
