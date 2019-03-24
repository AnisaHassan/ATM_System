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
            using (StreamWriter fileWriter = new FileInfo("Seperationslog.txt").AppendText())
            {
                fileWriter.WriteLine(planeliste);
            }

        }
    }
}
